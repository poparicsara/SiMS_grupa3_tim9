   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:IS_Bolnica
IS_Bolnica  5   	   "    IS_Bolnica.DoctorStartWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:IS_Bolnica     5   	     � Title$  DoctorStartWindow��5   	   $	��768��6#   $
��1024��60    � 
ResizeMode$ NoResize=�6=    � WindowStartupLocation$ CenterScreen=�6S   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��334* �6   �� 5      $
��405* �6   .+�5   
   � $
��Left=�6   $	��739��6*   $	��Top=�67   $	��100��6O   ���	#FFF1F0F0$��0q�6r   $��2��6}   .+�5      �� -   5        $
��Left=�5      $��	0,110,0,0q�60   $	��Top=�6C   $	��100��6[   $��51��6g   ��6s   Z� ��6�   Z� .��5      �� .+�5      �� $$��../Images/greenstethoscope.png��6   $��84��6D   $��48��6O   5      5      �� 5      -   5        $
��Left=�5      $��	0,195,0,0q�61   $	��Top=�6D   $	��100��6\   $��51��6h   ��6t   Z� ��6�   Z� .��5      �� .+�5      �� $!��../Images/greenscissors.png��6   $��84��6A   $��48��6L   5      5      �� 5      -   5        $
��Left=�5      $��	0,270,0,0q�61   $	��Top=�6D   $	��100��6\   $��51��6h   ��6t   Z� ��6�   Z� .��5      �� .+�5      �� $��../Images/message.png��6   $��84��6;   $��48��6F   5      5      �� 5      -   5        $
��Left=�5      $��	0,350,0,0q�61   $	��Top=�6D   $	��100��6\   $��51��6h   ��6t   Z� ��6�   Z� .��5      �� .+�5       �� $��../Images/pharmacy.png��6   $��84��6<   $��48��6G   5!      5"      5#      �� 5$   
   -   5        $
��Left=�5$      $��0,96,0,0q�6,   $	��Top=�6>   $	��100��6V   $��51��6b   $��1��6�   ��6n   Z� ��6�   Z� .��5%      �� .+�5&      �� $��../Images/chartgreen.png��6   $��84��6:   $��48��6E   5'      5(      �� 5)   
   -   5        $
��Left=�5)      $��	0,337,0,0q�6,   $	��Top=�6?   $	��100��6W   $��51��6c   $��1��6�   ��6o   Z� ��6�   Z� .��5*      �� .+�5+      �� $��../Images/singout.png��6   $��84��67   $��48��6B   5,      5-      �� 5.   
   -   5        $
��Left=�5.      $��	0,270,0,0q�6,   $	��Top=�6?   $	��100��6W   $��51��6c   $��1��6�   ��6o   Z� ��6�   Z� .��5/      �� .+�50      �� $��../Images/settings.png��6   $��84��68   $��48��6C   51      52      � 53   
   $
��Left=�6   $��91��6*   $	��Top=�66   $
��1008��6N   ���	#FFF1F0F0$��10,0,0,0q�6r   .+�54      �� -   5        $
��Left=�54      $��
909,38,0,0q�60   $	��Top=�6D   $��70��6\   $��53��6g   ��6s   Z� ��6�   Z� .��55      �� .+�56      �� $��../Images/remove2.png��6   $��30��6;   $��30��6F   57      58      �� 59      $��Pregledi��6   $
��Left=�6'   $��
110,20,0,0q�6B   $	��Top=�6V   $	��198��6n   $��Malgun Gothic)�6z   $��36(�6�   $
��Bold"�6�   $��71��6�   5:      �� 5;   
   -	   5        $
��Left=�5;      $��
849,37,0,0q�6,   $	��Top=�6@   $��64��6X   $��54��6c   ��6o   Z� ��6�   Z� .��5<      �� .+�5=      �� $��../Images/editt.png��6   $��30��65   $��30��6@   5>      5?      �� 5@   
   -
   5        $
��Left=�5@      $��
775,37,0,0q�6,   $	��Top=�6@   $��69��6X   $��54��6c   |�.  ��6o   Z� ��6�   Z� .��5A      �� .+�5B      �� $��../Images/add2.png��6   $��30��64   $��30��6?   5C      5D      &   System.Windows.Controls.DataGrid  5E   
   -   5        $��examinationsDataGrid��5E      $
��Left=�6/   $	��412��6J   $��208,174,0,0q�6W   $	��Top=�6l   $	��661��5F      
���   �$��14(�6I   $��Malgun Gothic)�6W   $
��Bold"�6r   
�������   SelectionMode$ Single=�5G   &      CanUserReorderColumns .     CanUserResizeColumns .     
IsReadOnly .    AutoGenerateColumns .  $	   HorizontalScrollBarVisibility$	 Disabled=�5H   A   
   CanUserResizeRows
 .  $��2��6�      HeadersVisibility$ Column=�6�   ��5F      Z�  � 	Resources 5I      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%9  '        �� 5J      "  6   .�5K      ��  � �� �	#FF3F503863   �� 5L       � ��
 �����63   �� 5M       � ��$ Center=�6C   �� 5N       � ��$ 30��6/   �� 5O       � ��$ 1q�68   �� 5P       � �� 64   Z� �� 5Q       � ��$
 Bold"�63   5R      5S         Columns 5T      0  *System.Windows.Controls.DataGridTextColumn  5U      ,  &System.Windows.Controls.DataGridColumn   Header$	 IME��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 160 62   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *Patient.Name+  5V      $ PREZIME��6%   $	 160 66    6B   �� *Patient.Surname+  5W      $ DATUM��6%   $	 120 64    6@   �� *	StartTime+ �� StringFormat$ 
dd/MM/yyyy��  5X      $ VREME��6%   $ 90 64    6?   �� *	StartTime+$ HH:mm��  5Y      $ 
ORDINACIJA��6%   $	 130 69    6E   �� *Doctor.Ordination+5[      �� 5\   
   -   5        $��startExaminationButton��5\      $��Započni pregled��6/   $
��Left=�6I   $��711,270,0,0q�6d   $��1��6y   $	��Top=�6�   $	��158��6�   $��48��6�   ���	#FF3F5038
�������$
��Bold"�6�   $��Malgun Gothic)�6�   $��14(�6  5]      5^      5_      