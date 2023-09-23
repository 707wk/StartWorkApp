Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Module Module1

    Private Const WM_KEYDOWN = &H100
    Private Const WM_KEYUP = &H101

    Private Const VK_RETURN = &HD

    <DllImport("User32.dll")>
    Private Function FindWindow(lpClassName As String, lpWindowName As String) As IntPtr

    End Function

    <DllImport("User32.dll")>
    Private Function SetForegroundWindow(hWnd As IntPtr) As Boolean

    End Function

    <DllImport("User32.dll")>
    Private Function PostMessage(hWnd As IntPtr, Msg As UInt32, wParam As Int32, lParam As Int32) As Boolean

    End Function

    Sub Main()

        For Each item In IO.Directory.GetFiles(My.Settings.AppFilePath, "*.lnk")
            Debug.WriteLine(item)

            ' 启动失败
            If Wangk.ResourceWPF.FileHelper.Open(item) <> 42 Then

                Process.Start(item)

            End If

        Next

        ' 点击微信登录按钮
        Do
            Dim WeChatLoginWndHandle = FindWindow("WeChatLoginWndForPC", Nothing)
            If WeChatLoginWndHandle = 0 Then
                Threading.Thread.Sleep(500)
                Continue Do
            End If

            Threading.Thread.Sleep(500)

            PostMessage(WeChatLoginWndHandle, WM_KEYDOWN, New IntPtr(VK_RETURN), New IntPtr(0))
            PostMessage(WeChatLoginWndHandle, WM_KEYUP, New IntPtr(VK_RETURN), New IntPtr(0))

            Exit Do
        Loop


    End Sub

End Module
