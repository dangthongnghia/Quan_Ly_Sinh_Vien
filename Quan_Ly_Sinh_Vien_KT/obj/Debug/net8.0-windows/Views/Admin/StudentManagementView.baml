   M S B A M L   `   `   `  ����O  KQuan_Ly_Sinh_Vien_KT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Quan_Ly_Sinh_Vien_KTQuan_Ly_Sinh_Vien_KT  5      <    6Quan_Ly_Sinh_Vien_KT.Views.Admin.StudentManagementView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Quan_Ly_Sinh_Vien_KT     5        � 	Resources  5         
LabelStyle �� 
TargetType �� Property �� Value  
InputStyle  ButtonStyle��%u  &	        &	 �     &	 V    �� 5   
   " ��6#   .�5      ��  � ��$ 5,5,15,5q�6'   �� 5       � ��$ Center=�62   �� 5       � ��$ Medium"�6+   �� 5       � ��$ 13(�6)   5      �� 5   
   " ��6#   .�5      ��  � ��$ 5,5,5,5q�6'   �� 5       � ��$ 5q�6(   �� 5       � ��$ 32��6'   5      �� 5   
   " ��6$   .�5      ��  � ��$ 5q�6'   �� 5       � ��$
 10,5q�6(   �� 5       � ��$	 100��6&   �� 5        � ��$ 35��6'   �� 5!       � ��$ Medium"�6+   �� 5"       � ��$ 0q�60   5#      5$      .��5&      �� 
������� �� CornerRadius$ 8��6    $��10q�61    J� Effect 5'   
   3  -System.Windows.Media.Effects.DropShadowEffect  5(         
BlurRadius$ 10Q�6      ShadowDepth$ 1Q�6/      Opacity$	 0.2Q�6?   ._�5+   
   � $��15q�6   	 � RowDefinitions	 5,      �� 5-      $
��Auto �6    �� 5.      $
��Auto �6    �� 5/      $��* �6    .+�53      �� $��0��6   ���#EEEEEE$��0,0,0,1q�68   
 �� Padding$
 0,0,0,15q�6R   ._�54      �� $��QUẢN LÝ SINH VIÊN��6   $��22(�55      $
��Bold"�6'   ���#2196F369   56      �� 59      $��1��6   ���#EEEEEE$��0,0,0,1q�68   $
 	0,15,0,15q�6R   ._�5:      �  � ColumnDefinitions 5;      �� 5<      $	��150 �6+   �� 5=      $��* �6+   	 5@      �� 5A      $
��Auto �6(   �� 5B      $
��Auto �6(   �� 5C      $
��Auto �6(   �� 5D      $
��Auto �6(   �� 5E      $
��Auto �6(   �� 5F      $
��Auto �6(   .+�5J      �� $��0��6    $��0��6-   $��Mã sinh viên:��6=   #��[  6R   �� 5K      -   5         ��Name$ txtStudentId��5K   ;   $��0��6   $��1��6+   #��[ 6Q   �� 5N      $��1��6    $��0��6-   $��Họ và tên:��6=   #��[  6O   �� 5O      -   5        $ txtStudentName��5O   ;   $��1��6   $��1��6+   #��[ 6S   �� 5R      $��2��6    $��0��6-   $��Ngày sinh:��6=   #��[  6O   (  "System.Windows.Controls.DatePicker  5S      -   5          Name$ 
dpBirthday��5S   >   $��2��6!   $��1��6.   #��[ 6R   �� 5V      $��3��6    $��0��6-   $��Tỉnh/Thành phố:��6=   #��[  6T   �� 5W      -   5         ��Name$ 
cbProvince��5W   <   $��3��6   $��1��6,   #��[ 6P   �� 5Z      $��4��6    $��0��6-   $��Giới tính:��6=   #��[  6O   �� 5[      -   5        $ cbGender��5[   <   $��4��6   $��1��6,   #��[ 6N   ��5\      �� *GenderOptions+ �� SelectedItem 6C   �� *SelectedGender+ �� Mode$ TwoWay=���5]      �� 5^      .R�5_   "   �� ��6,   �� 5`      5b      �� 5e      $��5��6!   $��0��6.   $��2��6>    �� Orientation$ 
Horizontal=�5f   !   $��Center=�6:   $��0,20,0,0q�6W   .+�5g      �� -   5         ��Name$ btnAddStudent��5g   !   $��Thêm mới��68   #��[ 6K   ���#2196F3
�������5h   6   �� 5i      -   5        $ btnUpdateStudent��5i   !   $��Cập nhật��6;   #��[ 6N   ���#FF9800
�������5j   6   �� 5k      -   5        $ btnDeleteStudent��5k   !   $
��Xóa��6;   #��[ 6I   ���#F44336
�������5l   6   �� 5m      -	   5        $ btnClearStudent��5m   !   $��
Làm mới��6:   #��[ 6L   ���#607D8B
�������5n   6   5o      5p      5q      � 5t      $��2��6   $��0,15,0,0q�6    .+�5u      &   System.Windows.Controls.DataGrid  -
   5          Name$ 
dgStudents��5u         AutoGenerateColumns$ False��6/      
IsReadOnly$
 True��5v         AlternatingRowBackground �#F5F5F5$��1q�5w      ���#DDDDDD   CanUserAddRows$ False��5x         CanUserDeleteRows$ False��60      HeadersVisibility$ Column=�5y        5z      =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�   '        �� 5{      "  6    .�5|      ��  � �� �#E3F2FD6;   �� 5}       � ��$ SemiBold"�6;   �� 5~       � ��$
 10,8q�68   �� 5       � ��$ 0,0,1,0q�6@   �� 5�       � �� �#BBDEFB6<   5�      5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã SV��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Id+6S     5�      $ Họ và tên��6-   $ * 6Y    6@   �� *Name+6Y     5�      $ 
Ngày sinh��6-   $	 120 6q    6@   �� *BOF+ �� StringFormat$ 
dd/MM/yyyy��6q     5�      $ Tỉnh/Thành phố��6-   $	 150 6b    6E   �� *
Province+6b     5�      $ Giới tính��6-   $	 100 6[    6@   �� *Gender+6[   5�      5�      5�      5�      5�      