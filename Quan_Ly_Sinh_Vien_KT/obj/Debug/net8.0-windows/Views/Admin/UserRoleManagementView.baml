   M S B A M L   `   `   `  ����O  KQuan_Ly_Sinh_Vien_KT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Quan_Ly_Sinh_Vien_KT.Views.Admin Quan_Ly_Sinh_Vien_KT.Views.Admin  5   	   =    7Quan_Ly_Sinh_Vien_KT.Views.Admin.UserRoleManagementView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:Quan_Ly_Sinh_Vien_KT.Views.Admin     5   	   .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $"��PHÂN QUYỀN NGƯỜI DÙNG��6!   $��20(�5      $
��Bold"�6"   $��	0,10,0,20q�64   ���#2196F36G   � 5   
   $��1��6   $��0,0,0,10q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#     5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5#      �� $��0��6   $��0��6%   $	��ID:��65   $��5q�6@   �� 5$      -   5         ��Name$ txtId��5$   3   $��0��6   $��1��6#   $��5q�6B   $��3q�6M   ${�False��5%      �� 5'      $��1��6   $��0��6%   $��Người dùng:��65   $��5q�6H   �� 5(      -   5         ��Name$ cbUser��5(   4   $��1��6   $��1��6$   $��5q�6D    �� DisplayMemberPath$ Username��5)      �� 5+      $��2��6   $��0��6%   $��	Vai trò:��65   $��5q�6E   �� 5,      -   5        $ cbRole��5,   4   $��2��6   $��1��6$   $��5q�6D   $ RoleName��5-      5/      �� 51      $��3��6   $��0��6&   $��2��66    �� Orientation$ 
Horizontal=�52      $��Center=�62   $��0,15,0,5q�6O   .+�53      �� -   5         ��Name$ btnAssignRole��53      $��Phân quyền��60   $	��120��6E   $��30��6Q   $��5q�6]   ���#2196F3
�������54   .   �� 55      -   5        $ btnRemoveRole��55      $��Xóa quyền��60   $	��120��6D   $��30��6P   $��5q�6\   ���#F44336
�������56   .   57      58      &   System.Windows.Controls.DataGrid  5;   
   -   5          Name$ dgUserRoles��5;       $��2��6      AutoGenerateColumns$ False��65   	   
IsReadOnly$
	 True��5<      
   AlternatingRowBackground
 �#F5F5F5   Columns 5=      0  *System.Windows.Controls.DataGridTextColumn  5>      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5?      $ Người dùng��6%   $ * 6Y    69   �� *StudentName+6Y     5@      $ Vai trò��6%   $ * 6S    66   �� *
RoleName+6S   5B      5C      5D      