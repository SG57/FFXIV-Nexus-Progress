Public Class Memory

    Private EquippedWeaponIDAddress As Int32
    Private EquippedShieldIDAddress As Int32

    Public Sub CalculateAddresses()
        If IsAttached() Then
            EquippedWeaponIDAddress = CalculateAddress(My.Settings.InventoryAddress, My.Settings.EquippedWeaponIDOffset)
            EquippedShieldIDAddress = CalculateAddress(My.Settings.InventoryAddress, My.Settings.EquippedShieldIDOffset)
        End If
    End Sub

    Public Function GetEquippedWeaponID() As Int32
        Return ReadInt32(EquippedWeaponIDAddress)
    End Function

    Public Function GetEquippedShieldID() As Int32
        Return ReadInt32(EquippedShieldIDAddress)
    End Function

    Public Function GetLightAmount(ByVal weapon As Boolean) As Int16
        If weapon Then Return ReadInt16(EquippedWeaponIDAddress + My.Settings.SpiritBondOffset)
        Return ReadInt16(EquippedShieldIDAddress + My.Settings.SpiritBondOffset)
    End Function



    Private Function CalculateAddress(ByVal addr_ptrs() As Int32, ByVal final_offset As Int32) As Int32
        Dim addr As Int32 = ffxiv_proc.MainModule.BaseAddress
        For Each offset In addr_ptrs
            addr = Deref(addr, offset)
        Next
        Return addr + final_offset
    End Function

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        DetachFromProcess()
    End Sub

    Public Shared Function GetFFXivProcesses() As Process()
        Return Process.GetProcessesByName(FFXIV_PROCESS)
    End Function

    Public Function AttachToProcess(ByVal id As Integer) As Boolean
        If id <> ffxiv_proc_id Then DetachFromProcess()
        If ffxiv_proc_hdl <> IntPtr.Zero Then Return True ' attached already

        Try
            ffxiv_proc_id = id
            ffxiv_proc = Process.GetProcessById(ffxiv_proc_id)

            If Not IsNothing(ffxiv_proc) Then
                ffxiv_proc_hdl = OpenProcess(PROCESS_READ_QUERY, False, ffxiv_proc.Id)

                CalculateAddresses()
            End If
        Catch ex As Exception
            Debug.Print(ex.StackTrace & vbCrLf)
            DetachFromProcess()
        End Try

        Return ffxiv_proc_hdl <> IntPtr.Zero
    End Function

    Public Sub DetachFromProcess()
        If ffxiv_proc_hdl <> IntPtr.Zero Then CloseHandle(ffxiv_proc_hdl)
        ffxiv_proc_hdl = IntPtr.Zero
        ffxiv_proc_id = -1
    End Sub

    Private Function Deref(addr As IntPtr, offset As Int32) As Int32
        If addr = 0 Then Throw New Exception()
        Return ReadInt32(IntPtr.Add(addr, offset))
    End Function

    Private Function ReadInt16(ByVal addr As IntPtr) As Int16
        Dim _dataBytes(2) As Byte
        ReadProcessMemory(ffxiv_proc_hdl, addr, _dataBytes, 2, vbNull)
        Return BitConverter.ToInt16(_dataBytes, 0)
    End Function

    Private Function ReadInt32(ByVal addr As IntPtr) As Int32
        Dim _dataBytes(4) As Byte
        ReadProcessMemory(ffxiv_proc_hdl, addr, _dataBytes, 4, vbNull)
        Return BitConverter.ToInt32(_dataBytes, 0)
    End Function

    Public Function IsAttached() As Boolean
        Return ffxiv_proc_hdl <> IntPtr.Zero
    End Function

    Private Declare Function OpenProcess Lib "kernel32.dll" (ByVal dwDesiredAcess As UInt32, ByVal bInheritHandle As Boolean, ByVal dwProcessId As Int32) As IntPtr
    Private Declare Function ReadProcessMemory Lib "kernel32" (ByVal hProcess As IntPtr, ByVal lpBaseAddress As IntPtr, ByVal lpBuffer() As Byte, ByVal iSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Boolean
    Private Declare Function CloseHandle Lib "kernel32.dll" (ByVal hObject As IntPtr) As Boolean

    Private Const FFXIV_PROCESS As String = "ffxiv"
    Private Const PROCESS_VM_READ = &H10
    Private Const PROCESS_QUERY_INFORMATION = &H400
    Private Const PROCESS_READ_QUERY = PROCESS_VM_READ + PROCESS_QUERY_INFORMATION

    Private ffxiv_proc As Process
    Private ffxiv_proc_hdl As IntPtr = IntPtr.Zero
    Private ffxiv_proc_id As Integer = -1
End Class