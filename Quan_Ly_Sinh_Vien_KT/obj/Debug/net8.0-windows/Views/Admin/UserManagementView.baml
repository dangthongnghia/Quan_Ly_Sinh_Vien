   M S B A M L   `   `   `  ����O  KQuan_Ly_Sinh_Vien_KT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Quan_Ly_Sinh_Vien_KT.Views.Admin Quan_Ly_Sinh_Vien_KT.Views.Admin  5   	   9    3Quan_Ly_Sinh_Vien_KT.Views.Admin.UserManagementView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:Quan_Ly_Sinh_Vien_KT.Views.Admin     5   	   .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��QUẢN LÝ NGƯỜI DÙNG��6!   $��20(�5      $
��Bold"�6"   $��	0,10,0,20q�64   ���#2196F36G   � 5   
   $��1��6   $��0,0,0,10q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#     5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6    .+�5#      �� $��0��6   $��0��6%   $��Mã sinh viên:��65   $��5q�6J   � 5$      $��0��6   $��1��6     5%      �� 5&      $��2* �6'   �� 5'      $��* �6'   .+�5)      �� -   5         ��Name$ txtIdStudent��5)   *   $��0��6   $��5,5,2,5q�6@   $��3q�6Q   �� 5*      -   5         ��Name$ btnFindStudent��5*   )   $��1��6   $
��Tìm��6A   $��2,5,5,5q�6O   5+      �� 5-      $��1��6   $��0��6%   $��Tên sinh viên:��65   $��5q�6K   �� 5.      -   5        $ txtStudentName��5.   3   $��1��6   $��1��6#   $��5q�6K   $��3q�6V   ${�False��6b   �� 50      $��2��6   $��0��6%   $��Tên đăng nhập:��65   $��5q�6K   �� 51      -   5        $ txtUsername��51   3   $��2��6   $��1��6#   $��5q�6H   $��3q�6S   �� 53      $��3��6   $��0��6%   $��Mật khẩu:��65   $��5q�6F   G� 54      -   5         G�Name$ txtPassword��54   7   $��3��6   $��1��6'   $��5q�6L   $��3q�6W   �� 56      $��4��6   $��0��6&   $��2��66    �� Orientation$ 
Horizontal=�57      $��Center=�62   $��0,15,0,5q�6O   .+�58      �� -   5        $ 
btnAddUser��58      $��Thêm mới��6-   $��90��6@   $��30��6K   $��5q�6W   ���#2196F3
�������59   .   �� 5:      -   5        $ btnUpdateUser��5:      $��Cập nhật��60   $��90��6C   $��30��6N   $��5q�6Z   ���#FF9800
�������5;   .   �� 5<      -   5        $ btnDeleteUser��5<      $
��Xóa��60   $��90��6>   $��30��6I   $��5q�6U   ���#F44336
�������5=   .   �� 5>      -	   5        $ btnClearUser��5>      $��
Làm mới��6/   $��90��6A   $��30��6L   $��5q�6X   ���#607D8B
�������5?   .   5@      5A      &   System.Windows.Controls.DataGrid  5D   
   -
   5          Name$ dgUsers��5D       $��2��6      AutoGenerateColumns$ False��61      
IsReadOnly$
 True��5E      	   AlternatingRowBackground	 �#F5F5F5
   Columns
 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn   Header$ Id sinh viên��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *	IdStudent+6Y     5H      $ Tên đăng nhập��6%   $ * 6Y    6<   �� *
Username+6Y   4  .System.Windows.Controls.DataGridCheckBoxColumn  5I      $ Trạng thái��6)   $ 80 6X    6=   �� *Status+6X   5L      5M      5N      