Imports System.Net
Imports System.Runtime.InteropServices

Public Class Main

    ' url to the memory address config file
    Const MEMORY_ADDRESSES_CONFIG_URL = "https://raw.githubusercontent.com/SG57/FFXIV-Nexus-Progress/master/Memory-Addresses.txt"



    Dim _memory As Memory = New Memory





    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("A simple program that allows you to view the progress of your Nexus weapon upgrade in FFXIV." & vbCrLf & vbCrLf & "Try updating the memory addresses if it stops working, and let me know if they DO need updating." & vbCrLf & vbCrLf & vbCrLf & "Copyright ©  2014" & vbCrLf & "Cord Rehn <jordansg57@gmail.com>", MsgBoxStyle.Information, "About FFXIV Nexus Progress")
    End Sub

    Private Sub DonateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DonateToolStripMenuItem.Click
        System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=JordanSg57%40gmail%2ecom&lc=US&item_name=Freelance%20Developer&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donateCC_LG%2egif%3aNonHosted")
    End Sub





    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshProcessComboBoxItems()
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
            End If
        Else
            If ffxiv_processes.Length > 0 Then
                Me.comboProcesses.SelectedIndex = 0
            Else
                Me.comboProcesses.SelectedItem = Nothing
            End If
        End If

        comboProcesses_SelectionChangeCommitted(Nothing, Nothing)
    End Sub





    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles comboProcesses.DropDown
        refreshProcessComboBoxItems()
    End Sub

    Private Sub comboProcesses_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles comboProcesses.SelectionChangeCommitted
        Me.grpLight.Visible = False
        Me.timerRefresh.Enabled = False

        If IsNothing(Me.comboProcesses.SelectedItem) Then Return

        If Not _memory.AttachToProcess(Me.comboProcesses.SelectedItem) Then
            MsgBox("Failed to attach to FFXIV process ID: " & Me.comboProcesses.SelectedItem, MsgBoxStyle.Critical, "Process Error")
            Me.comboProcesses.SelectedItem = Nothing
        Else
            _memory.CalculateAddresses()

            Me.grpLight.Visible = True
            Me.timerRefresh.Enabled = True
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
            _memory.CalculateAddresses()
            

            MsgBox("Successfully updated to the memory addresses that were working as of: " & vbCrLf & vbCrLf & working_date, MsgBoxStyle.Information, "Updated Memory Addresses")


        Catch ex As WebException
            MsgBox("Timed out attempting to reach the update server:" &
                       vbCrLf & vbCrLf &
                       MEMORY_ADDRESSES_CONFIG_URL &
                       vbCrLf & vbCrLf &
                       "Make sure you have an internet connection and try again.", MsgBoxStyle.Critical, "Connection Timed Out")
        End Try
    End Sub

    Private Sub timerRefresh_Tick(sender As Object, e As EventArgs) Handles timerRefresh.Tick
        Dim ID = 0
        If checkShield.Checked Then
            ID = _memory.GetEquippedShieldID
        Else
            ID = _memory.GetEquippedWeaponID()
        End If


        ' check if the ID falls within the novus ID range
        If ID >= My.Settings.NexusIDStart And ID <= My.Settings.NexusIDStart + My.Settings.NexusNames.Count Then
            Me.progressLight.Value = Math.Min(_memory.GetLightAmount(Not checkShield.Checked), 2000)
            Me.lblProgress.Text = Me.progressLight.Value.ToString("N0") & " / 2,000" & vbCrLf & My.Settings.NexusNames(ID - My.Settings.NexusIDStart)
            Me.grpLight.Text = "Light - " & My.Settings.NexusTiers(Math.Floor(progressLight.Value / 200)) & " Activity"
        Else
            Me.progressLight.Value = 0
            Me.lblProgress.Text = "No Novus Equipped"
            Me.grpLight.Text = "Light"
        End If
    End Sub



    Private Sub LightInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LightInfoToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://www.reddit.com/r/ffxiv/comments/2gm1ru/nexus_light_information/")
    End Sub

    Private Sub BonusLightToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BonusLightToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://www.reddit.com/live/tlfmtjl4fteo")
    End Sub
End Class
