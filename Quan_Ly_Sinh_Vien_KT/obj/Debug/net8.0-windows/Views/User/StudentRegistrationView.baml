   M S B A M L   `   `   `  ����O  KQuan_Ly_Sinh_Vien_KT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Quan_Ly_Sinh_Vien_KT.Views.UserQuan_Ly_Sinh_Vien_KT.Views.User  5      =    7Quan_Ly_Sinh_Vien_KT.Views.User.StudentRegistrationView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:Quan_Ly_Sinh_Vien_KT.Views.User     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��ĐĂNG KÝ MÔN HỌC��6!   $��20(�5      $
��Bold"�6"   $��	0,10,0,20q�64   �� 5   
   $��1��6   ���#DDDDDD$��1q�64   $��0,0,0,10q�6H   ���#FFF8DC �� CornerRadius$ 5��5   &   ._�5      �� $��10q�6   $
��Wrap=�6$   �� 5      $
��Bold"�6   .�6(   Hướng dẫn:64   �� Dưới đây là danh sách các môn học bạn có thể đăng ký. Bấm vào nút "Đăng ký" để đăng ký môn học. Sau khi đăng ký thành công, bạn có thể xem danh sách môn học đã đăng ký trong mục "Môn học đã đăng ký".5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgAvailableSubjects��5       $��2��6      AutoGenerateColumns$ False��6=      
IsReadOnly$
 True��5          AlternatingRowBackground �#F5F5F5   HeadersVisibility$ Column=�5!         GridLinesVisibility$ 
Horizontal=�6.      Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Mã môn học��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 120 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Id+6P     5$      $	 Tên môn học��6%   $
 * 6S    6:   �� *Name+6S     5%      $	 Số tín chỉ��6%   $	
 100 6h    69   �� *	Credits+ �� TargetNullValue$ 3��6h   5'      5(      5)      