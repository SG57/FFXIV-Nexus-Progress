Imports System.Net
Imports System.Runtime.InteropServices

Public Class Main

    ' url to the memory address config file
    Const MEMORY_ADDRESSES_CONFIG_URL = "https://raw.githubusercontent.com/SG57/FFXIV-Nexus-Progress/master/Memory-Addresses.txt"



    Dim _memory As Memory = New Memory
    Dim _recordingLight As Boolean
    Dim _totalLightEarned(11) As Integer
    Dim _timeElapsed As Long = 1
    Dim _lastID As Int32
    Dim _jobPictures(11) As Image
    Dim _oldSelectedProcess As Object



    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("A simple program that allows you to view the progress of your Nexus weapon upgrade in FFXIV." & vbCrLf & vbCrLf & "Try updating the memory addresses if it stops working, and let me know if they DO need updating." & vbCrLf & vbCrLf & vbCrLf & "NOTE: Currently, memory addresses are only valid for the 1st character log-in for that client. You need to restart your whole client to use this after you log out even once!" & vbCrLf & vbCrLf & vbCrLf & "Copyright ©  2014" & vbCrLf & "Cord Rehn <jordansg57@gmail.com>", MsgBoxStyle.Information, "About FFXIV Nexus Progress")
    End Sub

    Private Sub DonateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DonateToolStripMenuItem.Click
        System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=JordanSg57%40gmail%2ecom&lc=US&item_name=Freelance%20Developer&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donateCC_LG%2egif%3aNonHosted")
    End Sub

    Public Sub checkAlwaysOnTop_CheckedChanged(sender As Object, e As EventArgs) Handles checkAlwaysOnTop.CheckedChanged
        Me.TopMost = checkAlwaysOnTop.Checked
        My.Settings.AlwaysOnTop = checkAlwaysOnTop.Checked
        My.Settings.Save()
    End Sub



    Public Function GetMemory() As Memory
        Return _memory
    End Function

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _jobPictures(0) = My.Resources.ResourceManager.GetObject("pld")
        _jobPictures(9) = _jobPictures(0)
        _jobPictures(1) = My.Resources.ResourceManager.GetObject("mnk")
        _jobPictures(2) = My.Resources.ResourceManager.GetObject("war")
        _jobPictures(3) = My.Resources.ResourceManager.GetObject("drg")
        _jobPictures(4) = My.Resources.ResourceManager.GetObject("brd")
        _jobPictures(5) = My.Resources.ResourceManager.GetObject("whm")
        _jobPictures(6) = My.Resources.ResourceManager.GetObject("blm")
        _jobPictures(7) = My.Resources.ResourceManager.GetObject("smn")
        _jobPictures(8) = My.Resources.ResourceManager.GetObject("sch")
        _jobPictures(10) = My.Resources.ResourceManager.GetObject("nin")

        refreshProcessComboBoxItems()
    End Sub

    Private Sub Main_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ' top most load
        Me.TopMost = My.Settings.AlwaysOnTop
        RemoveHandler Me.checkAlwaysOnTop.CheckedChanged, AddressOf checkAlwaysOnTop_CheckedChanged
        checkAlwaysOnTop.Checked = Me.TopMost
        AddHandler Me.checkAlwaysOnTop.CheckedChanged, AddressOf checkAlwaysOnTop_CheckedChanged
    End Sub



    Private Sub refreshProcessComboBoxItems()
        Dim old_selected_item = Me.comboProcesses.SelectedItem
        Me.comboProcesses.Items.Clear()

        Dim ffxiv_processes As Process() = Memory.GetFFXivProcesses()
        For Each proc In ffxiv_processes
            Me.comboProcesses.Items.Add(proc.Id)
        Next

        If Not IsNothing(old_selected_item) Then
            If Me.comboProcesses.Items.Contains(old_selected_item) Then
                Me.comboProcesses.SelectedItem = old_selected_item
                Exit Sub
            End If
        End If

        If ffxiv_processes.Length > 0 Then
            Me.comboProcesses.SelectedIndex = 0
        Else
            Me.comboProcesses.SelectedItem = Nothing
        End If

        comboProcesses_SelectionChangeCommitted(Nothing, Nothing)
    End Sub





    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles comboProcesses.DropDown
        refreshProcessComboBoxItems()
    End Sub

    Private Sub comboProcesses_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles comboProcesses.SelectionChangeCommitted
        If Not IsNothing(_oldSelectedProcess) Then If _oldSelectedProcess.Equals(Me.comboProcesses.SelectedItem) Then Exit Sub

        _oldSelectedProcess = comboProcesses.SelectedItem
        Me.grpLight.Visible = False
        Me.timerRefresh.Enabled = False
        _recordingLight = False

        If IsNothing(Me.comboProcesses.SelectedItem) Then Return

        If Not _memory.AttachToProcess(Me.comboProcesses.SelectedItem) Then
            MsgBox("Failed to attach to FFXIV process ID: " & Me.comboProcesses.SelectedItem, MsgBoxStyle.Critical, "Process Error")
            Me.comboProcesses.SelectedItem = Nothing
            _oldSelectedProcess = Nothing
        Else
            _memory.CalculateAddresses(My.Settings.InventoryAddress, My.Settings.EquippedWeaponIDOffset, My.Settings.EquippedShieldIDOffset)

            ' refresh all initially
            Dim ID = GetEquippedID()
            _lastID = ID
            RefreshJobPicture(ID)
            RefreshAll(ID)
            RecordLastLight(ID, 0) ' reset the 'last light' 

            Me.grpLight.Visible = True
            Me.timerRefresh.Enabled = True
            _recordingLight = True
        End If
    End Sub






    Private Sub CheckForUpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckForUpdateToolStripMenuItem.Click
        UpdateMemoryAddresses()
    End Sub

    Private Sub UpdateMemoryAddresses()
        Try
            Dim working_date As String = "7/29/2014"

            Dim config_file = New WebClient().DownloadString(MEMORY_ADDRESSES_CONFIG_URL).Split(New Char() {ChrW(10), ChrW(&HD0A), vbCrLf}, StringSplitOptions.RemoveEmptyEntries)

            For Each line In config_file
                Dim setting() = line.Split(New String() {"="}, 2, StringSplitOptions.None)

                Select Case setting(0).Trim
                    Case "WorkingDate"
                        working_date = setting(1)


                    Case "InventoryAddress"
                        Dim inventory_offsets() = setting(1).Split(New String() {","}, StringSplitOptions.RemoveEmptyEntries)

                        My.Settings.InventoryAddress = New Integer(inventory_offsets.Length - 1) {}

                        For i As Integer = 0 To inventory_offsets.Length - 1
                            My.Settings.InventoryAddress(i) = Convert.ToInt32(inventory_offsets(i).Trim().Substring(2), 16)
                        Next


                    Case "EquippedWeaponIDOffset"
                        My.Settings.EquippedWeaponIDOffset = Convert.ToInt32(setting(1).Trim().Substring(2), 16)

                    Case "EquippedShieldIDOffset"
                        My.Settings.EquippedShieldIDOffset = Convert.ToInt32(setting(1).Trim().Substring(2), 16)

                    Case "SpiritBondOffset"
                        My.Settings.SpiritBondOffset = Convert.ToInt32(setting(1).Trim().Substring(2), 16)

                End Select
            Next

            My.Settings.Save()

            ' recalc addresses using the newly updated ones stored in settings
            _memory.CalculateAddresses(My.Settings.InventoryAddress, My.Settings.EquippedWeaponIDOffset, My.Settings.EquippedShieldIDOffset)
            

            MsgBox("Successfully updated to the memory addresses that were working as of: " & vbCrLf & vbCrLf & working_date & vbCrLf & vbCrLf & "NOTE: These are only valid for the first character log-in!", MsgBoxStyle.Information, "Updated Memory Addresses")


        Catch ex As WebException
            MsgBox("Timed out attempting to reach the update server:" &
                       vbCrLf & vbCrLf &
                       MEMORY_ADDRESSES_CONFIG_URL &
                       vbCrLf & vbCrLf &
                       "Make sure you have an internet connection and try again.", MsgBoxStyle.Critical, "Connection Timed Out")
        End Try
    End Sub



    Dim gr As Graphics

    Private Sub timerRefresh_Tick(sender As Object, e As EventArgs) Handles timerRefresh.Tick
        _timeElapsed += Me.timerRefresh.Interval

        Dim ID = GetEquippedID()
        If ID <> _lastID Then ' determine if we should record a potential light change
            _recordingLight = False ' only if the equipped IDs didn't change
            RecordLastLight(ID, 0)
            RefreshJobPicture(ID)
        End If
        _lastID = ID

        RefreshAll(ID)

        _recordingLight = True
    End Sub





    Private Function IsIDNovus(ByVal ID As Int32) As Boolean
        If ID = My.Settings.NinjaID Then Return True
        Return ID >= My.Settings.NexusIDStart And ID <= My.Settings.NexusIDStart + 10
    End Function

    Private Function GetEquippedID() As Int32
        If checkShield.Checked Then
            Return _memory.GetEquippedShieldID
        End If
        Return _memory.GetEquippedWeaponID()
    End Function

    Private Function GetIndexForID(ByVal id As Int32) As Integer
        If id = My.Settings.NinjaID Then Return 10
        Return id - My.Settings.NexusIDStart
    End Function



    Private Sub RefreshAll(ByVal ID As Int32)
        ' check if the ID falls within the novus ID range
        If IsIDNovus(ID) Then
            Dim last_Light = Me.progressLight.Value
            Me.progressLight.Value = Math.Min(_memory.GetLightAmount(Not checkShield.Checked), 2000)

            If last_Light < Me.progressLight.Value Then
                RefreshLight(ID)

                If _recordingLight Then
                    RecordLastLight(ID, Me.progressLight.Value - last_Light)
                End If
            End If

            Me.lblLightPerHour.Text = "LPH" & vbCrLf & FormatNumber(_totalLightEarned(GetIndexForID(ID)) / _timeElapsed * (1000 * 60 * 60), 1)

        Else
            Me.progressLight.Value = 0
            Me.lblProgress.Text = "No Novus Equipped"
            Me.grpLight.Text = "Light"
            Me.lblBrightsRemaining.Text = "Brights" & vbCrLf & "-"
            Me.lblGentlesRemaining.Text = "Gentles" & vbCrLf & "-"
            Me.lblTotalLightToday.Text = "Total" & vbCrLf & "-"
            Me.lblLastLightEarned.Text = "-"
            Me.lblLightPerHour.Text = "LPH" & vbCrLf & "-"
        End If
    End Sub

    Private Sub RefreshJobPicture(ByVal ID As Int32)
        If IsIDNovus(ID) Then
            Me.pictureJob.Image = _jobPictures(GetIndexForID(ID))
        Else
            Me.pictureJob.Image = Nothing
        End If
    End Sub

    Private Sub RefreshLight(ByVal ID As Int32)
        Me.lblProgress.Text = Me.progressLight.Value.ToString("N0") & " / 2,000" & vbCrLf & My.Settings.NexusNames(GetIndexForID(ID))
        Me.grpLight.Text = "Light - " & Math.Floor(progressLight.Value / progressLight.Maximum * 100) & "% - " & My.Settings.NexusTiers(Math.Floor(progressLight.Value / 200)) & " Activity"

        Me.lblBrightsRemaining.Text = "Brights" & vbCrLf & "-" & Math.Ceiling((2000 - Me.progressLight.Value) / 4).ToString("N0")
        Me.lblGentlesRemaining.Text = "Gentles" & vbCrLf & "-" & Math.Ceiling((2000 - Me.progressLight.Value) / 2).ToString("N0")
    End Sub

    Private Sub RecordLastLight(ByVal ID As Int32, ByVal light As Integer)
        Dim novus_index = GetIndexForID(ID)

        If light <= 0 Then
            Me.lblLastLightEarned.Text = "-"
        Else
            Me.lblLastLightEarned.Text = "+" & light
            _totalLightEarned(novus_index) += light
        End If

        If IsIDNovus(ID) Then
            Me.lblTotalLightToday.Text = "Total" & vbCrLf & "+" & _totalLightEarned(novus_index)
        Else
            Me.lblTotalLightToday.Text = "Total" & vbCrLf & "-"
        End If
    End Sub







    Private Sub LightInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LightInfoToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://www.reddit.com/r/ffxiv/comments/2gm1ru/nexus_light_information/")
    End Sub

    Private Sub BonusLightToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BonusLightToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://www.reddit.com/live/tlfmtjl4fteo")
    End Sub




    Private Sub lblLightPerHour_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lblLightPerHour.MouseDoubleClick
        ResetLight()
    End Sub

    Private Sub lblTotalLightToday_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lblTotalLightToday.MouseDoubleClick
        ResetLight()
    End Sub

    Private Sub lblLastLightEarned_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lblLastLightEarned.MouseDoubleClick
        ResetLight()
    End Sub

    Private Sub ResetLight()
        _timeElapsed = 0

        For i = 0 To _totalLightEarned.Count - 1
            _totalLightEarned(i) = 0
        Next
        RecordLastLight(GetEquippedID, 0)

        MsgBox("Reset the total Light earned, last light earned & Light-Per-Hour Timer for all Novuses!", MsgBoxStyle.Information, "LPH Timer Reset")
    End Sub
End Class
