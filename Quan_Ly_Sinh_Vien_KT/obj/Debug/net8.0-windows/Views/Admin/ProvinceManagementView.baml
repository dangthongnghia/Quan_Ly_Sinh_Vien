   M S B A M L   `   `   `  ����O  KQuan_Ly_Sinh_Vien_KT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Quan_Ly_Sinh_Vien_KT.Views.Admin Quan_Ly_Sinh_Vien_KT.Views.Admin  5   	   =    7Quan_Ly_Sinh_Vien_KT.Views.Admin.ProvinceManagementView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:Quan_Ly_Sinh_Vien_KT.Views.Admin     5   	   .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $$��QUẢN LÝ TỈNH/THÀNH PHỐ��6!   $��20(�5      $
��Bold"�6"   $��	0,10,0,20q�64   ���#2196F36G   � 5   
   $��1��6   $��0,0,0,10q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#     5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5!      �� $��0��6   $��0��6%   $��Mã tỉnh/thành phố:��65   $��5q�6O   �� 5"      -   5         ��Name$ txtProvinceId��5"   3   $��0��6   $��1��6#   $��5q�6J   $��3q�6U   �� 5$      $��1��6   $��0��6%   $��Tên tỉnh/thành phố:��65   $��5q�6P   �� 5%      -   5        $ txtProvinceName��5%   3   $��1��6   $��1��6#   $��5q�6L   $��3q�6W   �� 5'      $��2��6   $��0��6&   $��2��66    �� Orientation$ 
Horizontal=�5(      $��Center=�62   $��0,15,0,5q�6O   .+�5)      �� -   5         ��Name$ btnAddProvince��5)      $��Thêm mới��61   $��90��6D   $��30��6O   $��5q�6[   ���#2196F3
�������5*   A   �� 5+      -   5        $ btnUpdateProvince��5+      $��Cập nhật��64   $��90��6G   $��30��6R   $��5q�6^   ���#FF9800
�������5,   .   �� 5-      -   5        $ btnDeleteProvince��5-      $
��Xóa��64   $��90��6B   $��30��6M   $��5q�6Y   ���#F44336
�������5.   .   �� 5/      -   5        $ btnClearProvince��5/      $��
Làm mới��63   $��90��6E   $��30��6P   $��5q�6\   ���#607D8B
�������50   .   51      52      &   System.Windows.Controls.DataGrid  55   
   -   5          Name$ dgProvinces��55       $��2��6      AutoGenerateColumns$ False��65      
IsReadOnly$
 True��56         AlternatingRowBackground �#F5F5F5	   Columns	 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Mã tỉnh/TP��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Id+6P     59      $
 Tên tỉnh/thành phố��6%   $ * 6Z    6A   �� *Name+6Z   5;      5<      5=      