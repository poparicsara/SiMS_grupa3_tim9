   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:IS_Bolnica.DoctorUIIS_Bolnica.DoctorUI  5   	   4    .IS_Bolnica.DoctorUI.HospitalizedPatientsWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:IS_Bolnica.DoctorUI     5   	     � Title$   HospitalizedPatientsWindow��5   	   $	��768��6,   $
��1024��69    � 
ResizeMode$ NoResize=�6F    � WindowStartupLocation$ CenterScreen=�6\   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��334* �6   �� 5      $
��405* �6   .+�5   
   � $
��Left=�6   $��91��6*   $	��Top=�66   $
��1008��6N   ���	#FFF1F0F0$��10,0,0,0q�6r   .+�5      �� $��Hospitalizovani pacijenti��6   $
��Left=�68   $��
110,20,0,0q�6S   $	��Top=�6g   $	��456��6   $��Malgun Gothic)�6�   $��36(�6�   $
��Bold"�6�   $��71��6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $"��hospitalizedPatientsDataGrid��5      $
��Left=�67   $	��412��6R   $��212,180,0,0q�6_   $	��Top=�6t   $	��669��5      
���   �$��14(�6I   $��Malgun Gothic)�6W   $
��Bold"�6r   
�������   SelectionMode$ Single=�5   &      CanUserReorderColumns .     CanUserResizeColumns .     
IsReadOnly .    AutoGenerateColumns .  $	   HorizontalScrollBarVisibility$	 Disabled=�5   A   
   CanUserResizeRows
 .  $��2��6�      HeadersVisibility$ Column=�6�   ��5      Z�  � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%9  '        �� 5      "  6   .�5      ��  � �� �	#FF3F503863   �� 5       � ��
 �����63   �� 5       � ��$ Center=�6C   �� 5       � ��$ 30��6/   �� 5       � ��$ 1q�68   �� 5       � �� 64   Z� �� 5       � ��$
 Bold"�63   5      5         Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$	 IME��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 140 62   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *Patient.Name+  5"      $ PREZIME��6%   $	 140 66    6B   �� *Patient.Surname+  5#      $
 SOBA��6%   $	 100 63    6?   �� *	Room.Id+  5$      $ POČETAK LEČENJA��6%   $	 140 6>    6J   �� *	StartDate+ �� StringFormat$ 
dd/MM/yyyy��  5%      $ KRAJ LEČENJA��6%   $	 140 6;    6G   �� *	EndDate+$ 
dd/MM/yyyy��5'      �� 5(   
   -   5         ��Name$ 
prolongBTN��5(      $��Produži lečenje��6%   $
��Left=�6?   $��212,270,0,0q�6Z   $	��Top=�6o   $	��148��6�   $��42��6�   ���	#FF3F5038
�������$
��Bold"�6�   $��Malgun Gothic)�6�   $��14(�6�   $��1��6  � 5)   
   $
��Left=�6   $	��739��6*   $	��Top=�67   $	��100��6O   ���	#FFF1F0F0$��0q�6r   $��2��6}   .+�5*      �� -   5        $
��Left=�5*      $��	0,110,0,0q�60   $	��Top=�6C   $	��100��6[   $��51��6g   ��6s   Z� ��6�   Z� .��5+      �� .+�5,      �� $7��1/IS_Bolnica;component/Images/greenstethoscope.png��6   $��84��6W   $��48��6b   5-      5.      �� 5/      -   5        $
��Left=�5/      $��	0,195,0,0q�61   $	��Top=�6D   $	��100��6\   $��51��6h   ��6t   Z� ��6�   Z� .��50      �� .+�51      �� $4��./IS_Bolnica;component/Images/greenscissors.png��6   $��84��6T   $��48��6_   52      53      �� 54      -   5        $
��Left=�54      $��	0,270,0,0q�61   $	��Top=�6D   $	��100��6\   $��51��6h   ��6t   Z� ��6�   Z� .��55      �� .+�56      �� $.��(/IS_Bolnica;component/Images/message.png��6   $��84��6N   $��48��6Y   57      58      �� 59      -   5        $
��Left=�59      $��	0,350,0,0q�61   $	��Top=�6D   $	��100��6\   $��51��6h   ��6t   Z� ��6�   Z� .��5:      �� .+�5;      �� $/��)/IS_Bolnica;component/Images/pharmacy.png��6   $��84��6O   $��48��6Z   5<      5=      5>      �� 5?   
   -   5        $
��Left=�5?      $��0,96,0,0q�6,   $	��Top=�6>   $	��100��6V   $��51��6b   $��1��6�   ��6n   Z� ��6�   Z� .��5@      �� .+�5A      �� $1��+/IS_Bolnica;component/Images/chartgreen.png��6   $��84��6M   $��48��6X   5B      5C      �� 5D   
   -   5        $
��Left=�5D      $��	0,337,0,0q�6,   $	��Top=�6?   $	��100��6W   $��51��6c   $��1��6�   ��6o   Z� ��6�   Z� .��5E      �� .+�5F      �� $.��(/IS_Bolnica;component/Images/singout.png��6   $��84��6J   $��48��6U   5G      5H      �� 5I   
   -	   5        $
��Left=�5I      $��	0,270,0,0q�6,   $	��Top=�6?   $	��100��6W   $��51��6c   $��1��6�   ��6o   Z� ��6�   Z� .��5J      �� .+�5K      �� $/��)/IS_Bolnica;component/Images/settings.png��6   $��84��6K   $��48��6V   5L      5M      5N      5O      