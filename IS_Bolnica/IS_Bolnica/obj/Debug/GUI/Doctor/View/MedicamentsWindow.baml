   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:IS_Bolnica.DoctorUIIS_Bolnica.DoctorUI  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   2    ,IS_Bolnica.GUI.Doctor.View.MedicamentsWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:IS_Bolnica.DoctorUI     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$  MedicamentsWindow��5	   	   $	��768��6#   $
��1024��60    � 
ResizeMode$ NoResize=�6=    � WindowStartupLocation$ CenterScreen=�6S   .��5
      � .+�5   
   � $
��Left=�6   $	��739��6*   $	��Top=�67   $	��100��6O   ���	#FFF1F0F0$��0q�6r   .+�5      �� $
��Left=�6A   $��	0,110,0,0q�6\   $	��Top=�6o   $	��100��6�   $��51��6�   ��6   ��  �� Path$ ExaminationCommand���6�   Z� ��6�   Z� .��5      �� .+�5      �� $7��1/IS_Bolnica;component/Images/greenstethoscope.png��6   $��84��6W   $��48��6b   5      5      �� 5      $
��Left=�6?   $��	0,195,0,0q�6Z   $	��Top=�6m   $	��100��6�   $��51��6�   ��6   �� $ OperationCommand���6�   Z� ��6�   Z� .��5      �� .+�5      �� $4��./IS_Bolnica;component/Images/greenscissors.png��6   $��84��6T   $��48��6_   5      5      �� 5      $
��Left=�6B   $��	0,270,0,0q�6]   $	��Top=�6p   $	��100��6�   $��51��6�   ��6   �� $ NotificationCommand���6�   Z� ��6�   Z� .��5      �� .+�5      �� $.��(/IS_Bolnica;component/Images/message.png��6   $��84��6N   $��48��6Y   5      5      �� 5      $
��Left=�6@   $��	0,350,0,0q�6[   $	��Top=�6n   $	��100��6�   $��51��6�   ��6   �� $ MedicationCommand���6�   Z� ��6�   Z� .��5      �� .+�5      �� $/��)/IS_Bolnica;component/Images/pharmacy.png��6   $��84��6O   $��48��6Z   5      5      5       �� 5!   
   $
��Left=�67   $��	0,430,0,0q�6R   $	��Top=�6e   $	��100��6}   $��51��6�   ��6   �� $ ChartCommand���6�   Z� ��6�   Z� .��5"      �� .+�5#      �� $1��+/IS_Bolnica;component/Images/chartgreen.png��6   $��84��6M   $��48��6X   5$      5%      �� 5&   
   $
��Left=�68   $��	0,671,0,0q�6S   $	��Top=�6f   $	��100��6~   $��51��6�   ��6   �� $ LogoutCommand���6�   Z� ��6�   Z� .��5'      �� .+�5(      �� $.��(/IS_Bolnica;component/Images/singout.png��6   $��84��6J   $��48��6U   5)      5*      �� 5+   
   $
��Left=�6:   $��	0,604,0,0q�6U   $	��Top=�6h   $	��100��6�   $��51��6�   ��6   �� $ SettingsCommand���6�   Z� ��6�   Z� .��5,      �� .+�5-      �� $/��)/IS_Bolnica;component/Images/settings.png��6   $��84��6K   $��48��6V   5.      5/      � 50   
   $
��Left=�6   $��91��6*   $	��Top=�66   $
��1018��6N   ���	#FFF1F0F0.+�51      �� $��Spisak lekova��6   $
��Left=�6,   $��
110,20,0,0q�6G   $	��Top=�6[   $	��285��6s   $��Malgun Gothic)�6   $��36(�6�   $
��Bold"�6�   $��71��6�   52      &   System.Windows.Controls.DataGrid  53   
   -   5          Name$ medsDataGrid��53      $
��Left=�6)   $	��412��6D   $��231,178,0,0q�6Q   $	��Top=�6f   $	��609��54      
���   �$��14(�6C   $��Malgun Gothic)�6Q   $
��Bold"�6l   
�������   SelectionMode$ Single=�55          CanUserReorderColumns .     CanUserResizeColumns .     
IsReadOnly . 	   AutoGenerateColumns	 .  $
   HorizontalScrollBarVisibility$
 Disabled=�56   ;      CanUserResizeRows .     HeadersVisibility$ Column=�6~   ��54      Z� ��57      �� $ AllMedicaments� � 	Resources 58      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value)  #System.Windows.Controls.DataGridRow��%~  '        '  /    �� 59      "  6   .�5:      ��  � �� �	#FF3F503863   �� 5;       � ��
 �����63   �� 5<       � ��$ Center=�6C   �� 5=       � ��$ 30��6/   �� 5>       � ��$ 1q�68   �� 5?       � �� 64   Z� �� 5@       � ��$
 Bold"�63   5A      �� 5B      "  6   .�5C      -   5        5D      5E         Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn   Header$ 	BROJ LEKA��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 68   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   �� *Id+  5H      $ NAZIV��6%   $	 170 64    6@   �� *Name+  5I      $ ZAMENA��6%   $	 170 65    6A   �� *Replacement.Name+  5J      $ PROIZVOĐAČ��6%   $	 170 69    6E   �� *
Producer+5L      5N      5O      