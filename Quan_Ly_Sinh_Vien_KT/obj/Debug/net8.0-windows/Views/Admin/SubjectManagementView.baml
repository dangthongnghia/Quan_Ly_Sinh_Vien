   M S B A M L   `   `   `  ����O  KQuan_Ly_Sinh_Vien_KT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Quan_Ly_Sinh_Vien_KT.Views.Admin Quan_Ly_Sinh_Vien_KT.Views.Admin  5   	   <    6Quan_Ly_Sinh_Vien_KT.Views.Admin.SubjectManagementView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:Quan_Ly_Sinh_Vien_KT.Views.Admin     5   	   .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��QUẢN LÝ MÔN HỌC��6!   $��20(�5      $
��Bold"�6"   $��	0,10,0,20q�64   ���#2196F36G   � 5   
   $��1��6   $��0,0,0,10q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#     5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5"      �� $��0��6   $��0��6%   $��Mã môn học:��65   $��5q�6H   �� 5#      -   5         ��Name$ txtSubjectId��5#   3   $��0��6   $��1��6#   $��5q�6I   $��3q�6T   �� 5%      $��1��6   $��0��6%   $��Tên môn học:��65   $��5q�6I   �� 5&      -   5        $ txtSubjectName��5&   3   $��1��6   $��1��6#   $��5q�6K   $��3q�6V   �� 5(      $��3��6   $��0��6&   $��2��66    �� Orientation$ 
Horizontal=�5)      $��Center=�62   $��0,15,0,5q�6O   .+�5*      �� -   5         ��Name$ btnAddSubject��5*      $��Thêm mới��60   $��90��6C   $��30��6N   $��5q�6Z   ���#2196F3
�������5+   .   �� 5,      -   5        $ btnUpdateSubject��5,      $��Cập nhật��63   $��90��6F   $��30��6Q   $��5q�6]   ���#FF9800
�������5-   .   �� 5.      -   5        $ btnDeleteSubject��5.      $
��Xóa��63   $��90��6A   $��30��6L   $��5q�6X   ���#F44336
�������5/   .   �� 50      -   5        $ btnClearSubject��50      $��
Làm mới��62   $��90��6D   $��30��6O   $��5q�6[   ���#607D8B
�������51   .   52      53      &   System.Windows.Controls.DataGrid  56   
   -   5          Name$ 
dgSubjects��56       $��2��6      AutoGenerateColumns$ False��64      
IsReadOnly$
 True��57         AlternatingRowBackground �#F5F5F5	   Columns	 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Mã môn học��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Id+6P     5:      $
 Tên môn học��6%   $ * 6S    6:   �� *Name+6S   5=      5>      5?      