   M S B A M L   `   `   `  ����O  KQuan_Ly_Sinh_Vien_KT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Quan_Ly_Sinh_Vien_KT.Views.UserQuan_Ly_Sinh_Vien_KT.Views.User  5      8    2Quan_Ly_Sinh_Vien_KT.Views.User.StudentProfileView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:Quan_Ly_Sinh_Vien_KT.Views.User     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��THÔNG TIN CÁ NHÂN��6!   $��20(�5      $
��Bold"�6"   $��	0,10,0,20q�64   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $��10q�6%   ���#DDDDDD$��1q�6G    �� CornerRadius$ 5��5      ���#F9F9F9._�5      �� $��20q�6   .+�5      A� $	��120��6   $	��120��6*   $��Center=�67   $��	0,10,0,20q�6T   ��5      �� 5       �� Color$ #3498DB��6.   5       �� 5"      -   5         ��Name$ lblFullStudentName��5"       $��Nguyễn Văn A��6<   $��18(�5#       $
��Bold"�6.   $��Center=�6@   $��0,0,0,10q�5$       �� 5&      -   5        $ lblStudentId��5&       $��Mã SV: SV001��66   $��Center=�5'       $��0,0,0,20q�6=   5(      5)      �� 5+      $��1��6   $��10q�6%   ���#DDDDDD$��1q�6G   $ 5��5,      ._�5-      �� $��20q�6   .+�5.      �� $��THÔNG TIN SINH VIÊN��6    $
��Bold"�6;   $��0,0,0,20q�5/       $��Center=�62   � 51       52      �� 53      $	��120 �6/   �� 54      $��* �6/     56      �� 57      $
��Auto �6,   �� 58      $
��Auto �6,   �� 59      $
��Auto �6,   �� 5:      $
��Auto �6,   �� 5;      $
��Auto �6,   �� 5<      $
��Auto �6,   �� 5=      $
��Auto �6,   .+�5@      �� $��0��6$   $��0��61   $��Họ và tên:��6A   $��SemiBold"�5A   $   $��5q�6:   �� 5B      -   5         ��Name$ txtFullName��5B   ?   $��0��6"   $��1��6/   $��5q�6T   $��3q�6_   �� 5D      $��1��6$   $��0��61   $��Ngày sinh:��6A   $��SemiBold"�5E   $   $��5q�6:   (  "System.Windows.Controls.DatePicker  5F      -   5          Name$ 
dpBirthday��5F   B   $��1��6%   $��1��62   $��5q�6V   �� 5H      $��2��6$   $��0��61   $��Tên đăng nhập:��6A   $��SemiBold"�5I   $   $��5q�6:   �� 5J      -   5        $ txtUsername��5J   ?   $��2��6"   $��1��6/   $��5q�6T    �� 
IsReadOnly$
 True��6_   $��3q�6q   �� 5L      $��3��6$   $��0��61   $��Tỉnh/Thành phố:��6A   $��SemiBold"�5M   $   $��5q�6:   �� 5N      -   5         ��Name$ 
cbProvince��5N   @   $��3��6#   $��1��60   $��5q�6T   �� 5P      $��4��6$   $��0��61   $��Mật khẩu mới:��6A   $��SemiBold"�5Q   $   $��5q�6:   G� 5R      -   5        	 G�Name$	 txtNewPassword��5R   C   $��4��6&   $��1��63   $��5q�6[   $��3q�6f   �� 5T      -   5        
 ��Name$
 btnUpdateProfile��5U   !   $��6��5T   !   $��0��6.   $��2��6>   $��Cập nhật thông tin��6R   $��35��5U   ;   $��5,20,5,5q�6G   ���#2196F3
�������5V   6   5W      5X      5Y      5Z      5[      5\      