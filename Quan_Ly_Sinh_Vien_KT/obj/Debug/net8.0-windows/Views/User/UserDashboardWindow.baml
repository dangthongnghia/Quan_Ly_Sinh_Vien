   M S B A M L   `   `   `  ����O  KQuan_Ly_Sinh_Vien_KT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Quan_Ly_Sinh_Vien_KT.Views.UserQuan_Ly_Sinh_Vien_KT.Views.User  5   	   9    3Quan_Ly_Sinh_Vien_KT.Views.User.UserDashboardWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:Quan_Ly_Sinh_Vien_KT.Views.User     5   	     � Title$(  "Hệ thống Quản lý Sinh viên��5	   	   $	��700��6,   $
��1100��69    � WindowStartupLocation$ CenterScreen=�5
   	   ���#F5F5F5 � 	Resources 5         NavButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Triggers	 P� Property
 P� Value  NavButtonActiveStyle �� BasedOn��%
  &	        &	 L    7   �� 5   
   " ��6'   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       � ��$ 45��6'   �� 5       � ��$ 13(�6)   �� 5       � ��$
 Left=�6;   �� 5       � ��$ 15,0,0,0q�6(   �� 5       � ��$	 0,2q�6'   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   #��z��61   #��z��5   !   #��z��5   !   ._�5      �� $
��Left=�6/   $��Center=�6J   5       5       P� 5!      	 �@J�IsMouseOver$

 True��6=   . �5"   "   ��  � �� �#2860906?   �� 5#   "    � ��
 �����6?   5$      P� 5%      	 � ��$

 True��6;   . �5&   "   ��  � �� �#1F4E796?   5'      5)      5+      5,      �� 5/   
   " ��6-   8   .�50      ��  � �� �#2860906+   �� 51       � ��$ 4,0,0,0q�60   �� 52       � �� �#2ECC716,   53      54      .��56      �  � ColumnDefinitions 57   
   �� 58      $	��240 �6   �� 59      $��* �6   .+�5=   
   � $��0��6    � RowDefinitions 5>      �� 5?      $
��Auto �6    �� 5@      $��* �6    �� 5A      $
��Auto �6    .+�5E      �� $��0��6   ���#2471A3$	��160��67   ._�5F      �� $��Center=�6   .+�5G      A� $��70��6   $��70��6)   $
��0,10q�65   ��5H      �� 5I       �� Color$ #1ABC9C��6.   5K      �� 5L      $��TRƯỜNG ĐẠI HỌC��6    
�������$��SemiBold"�5M   3   $��Center=�5N       �� 5O      $��QUẢN LÝ SINH VIÊN��6    
�������$
��Bold"�5P   3   $��16(�6E   $��Center=�5Q       $��0,5,0,10q�6=   5R      5S      �� 5V      $��1��6   ���#3498DB._�5W      �� $��0,20,0,0q�6   .+�5Y      �� ���#2980B9 �� Padding$ 15,10q�62   $��0,0,0,15q�6B   ._�5Z      �� .+�5[      �� $��
Xin chào,��6(   ���#BBDEFB$��12(�6N   �� 5\      -   5         ��Name$ lblStudentName��5\   (   $��Nguyễn Văn A��6@   
�������$��SemiBold"�5]   ;   $��15(�6Q   �� 5^      -   5        $ lblStudentId��5^   (   $��Mã SV: SV001��6>   ���#BBDEFB$��12(�5_   =   $��0,5,0,0q�6K   5`      5a      �� 5d      $��MENU CHÍNH��6    ���#BBDEFB$
��15,5q�5e       $��11(�6.   $��SemiBold"�6<   �� 5g      -   5         ��Name$ 
btnProfile��5g      #��[  61   .��5i      ��  �� Orientation$ 
Horizontal=�6%   .+�5j      �� $	����6(   $��Segoe MDL2 Assets)�68   $��16(�5k   (   $��0,0,10,0q�66   �� 5l      $��Thông tin cá nhân��6(   5m      5n      �� 5p      -   5        $ btnRegisterSubjects��5p      #��[  6:   .��5r      �� $ 
Horizontal=�6%   .+�5s      �� $	����6(   $��Segoe MDL2 Assets)�68   $��16(�5t   (   $��0,0,10,0q�66   �� 5u      $��Đăng ký môn học��6(   5v      5w      �� 5y      -   5        $ btnMySubjects��5y      #��[  64   .��5{      �� $ 
Horizontal=�6%   .+�5|      �� $	����6(   $��Segoe MDL2 Assets)�68   $��16(�5}   (   $��0,0,10,0q�66   �� 5~      $ ��Môn học đã đăng ký��6(   5      5�      �� 5�      -   5        $ btnSchedule��5�      #��[  62   .��5�      �� $ 
Horizontal=�6%   .+�5�      �� $	����6(   $��Segoe MDL2 Assets)�68   $��16(�5�   (   $��0,0,10,0q�66   �� 5�      $��Lịch học��6(   5�      5�      �� 5�      -   5        $ 	btnGrades��5�      #��[  60   .��5�      �� $ 
Horizontal=�6%   .+�5�      �� $	����6(   $��Segoe MDL2 Assets)�68   $��16(�5�   (   $��0,0,10,0q�66   �� 5�      $��Điểm số��6(   5�      5�      5�      5�      �� 5�      $��2��6   ���#3498DB._�5�      �� -   5        $ 	btnLogout��5�      $��45��6,   $��15,10q�68   ���#E74C3C
�������$��0q�5�       5�      ��%^   '��       �� 5�      " ��6    .�5�      ��  �@��CornerRadius$ 4��6=   5�      5�      .��5�      �� $ 
Horizontal=�6!   .+�5�      �� $	����6$   $��Segoe MDL2 Assets)�64   $��16(�5�   $   $��0,0,10,0q�62   �� 5�      $��Đăng xuất��6$   5�      5�      5�      5�      � 5�   
   $��1��6    5�      �� 5�      $
��Auto �6    �� 5�      $��* �6    .+�5�      �� $��0��6   
�������$��60��65   $��0,0,0,1q�5�      ���#E0E0E0._�5�      �  5�      �� 5�      $��* �6+   �� 5�      $
��Auto �6+   .+�5�      �� -	   5        $ txtPageTitle��5�       $��Tổng quan��66   $��18(�5�       $��SemiBold"�6.   $��Center=�6D   $��20,0,0,0q�5�       �� 5�      $��1��6!   $ 
Horizontal=�61   $��0,0,20,0q�6J   .+�5�      �� -
   5        $ txtCurrentDate��5�   $   $��
17/04/2023��6<   $��Center=�5�   $   ���#7575756?   �� 5�      $	�� | ��6$   ���#BDBDBD$��Center=�6D   �� 5�      -   5        $ txtCurrentTime��5�   $   $��10:25 AM��6<   $��Center=�5�   $   ���#7575756?   5�      5�      5�      �� 5�      $��1��6   
�������$��15q�65    �� CornerRadius$ 5��6A   ._�5�      �� -   5         ��Name$ contentControl��5�   !   $��15q�69   5�      5�      5�      5�      