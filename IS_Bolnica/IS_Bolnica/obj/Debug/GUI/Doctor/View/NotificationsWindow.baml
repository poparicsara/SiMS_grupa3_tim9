   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:IS_Bolnica.DoctorUIIS_Bolnica.DoctorUI  5   	   4    .IS_Bolnica.GUI.Doctor.View.NotificationsWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:IS_Bolnica.DoctorUI     5   	     � Title$  NotificationsWindow��5   	   $	��768��6%   $
��1024��62    � 
ResizeMode$ NoResize=�6?    � WindowStartupLocation$ CenterScreen=�6U   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��334* �6   �� 5      $
��405* �6   .+�5   
   � $
��Left=�6   $��91��6*   $	��Top=�66   $
��1008��6N   ���	#FFF1F0F0$��10,0,0,0q�6r   .+�5      �� $��Obaveštenja i zahtevi��6   $
��Left=�64   $��
110,20,0,0q�6O   $	��Top=�6c   $	��454��6{   $��Malgun Gothic)�6�   $��36(�6�   $
��Bold"�6�   $��71��6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ requestsDataGrid��5      $
��Left=�6-   $	��348��6H   $��246,172,0,0q�6U   $	��Top=�6j   $	��536��5      
���   �$��14(�6C   $��Malgun Gothic)�6Q   $
��Bold"�6l   
�������   SelectionMode$ Single=�5          CanUserReorderColumns .     CanUserResizeColumns .     
IsReadOnly . 	   AutoGenerateColumns	 .  $
   HorizontalScrollBarVisibility$
 Disabled=�5   ;      CanUserResizeRows .  $��2��6~      HeadersVisibility$ Column=�6�   ��5      Z� ��5      �� *
Requests+ � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value)  #System.Windows.Controls.DataGridRow��%~  '        '  /    �� 5      "  6   .�5      ��  � �� �	#FF3F503863   �� 5       � ��
 �����63   �� 5       � ��$ Center=�6C   �� 5       � ��$ 30��6/   �� 5       � ��$ 1q�68   �� 5       � �� 64   Z� �� 5       � ��$
 Bold"�63   5      �� 5       "  6   .�5!      -   5        5"      5#         Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ NASLOV��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 270 65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *Title+  5&      $ POŠILJALAC��6%   $	 270 69    6E   �� *Sender+5)      � 5*   
   $
��Left=�6   $	��739��6*   $	��Top=�67   $	��100��6O   ���	#FFF1F0F0$��0q�6r   $��2��6}   .+�5+      �� $
��Left=�6A   $��	0,110,0,0q�6\   $	��Top=�6o   $	��100��6�   $��51��6�   ��6   ��  �� Path$ ExaminationCommand���6�   Z� ��6�   Z� .��5,      �� .+�5-      �� $7��1/IS_Bolnica;component/Images/greenstethoscope.png��6   $��84��6W   $��48��6b   5.      5/      �� 50      $
��Left=�6?   $��	0,195,0,0q�6Z   $	��Top=�6m   $	��100��6�   $��51��6�   ��6   �� $ OperationCommand���6�   Z� ��6�   Z� .��51      �� .+�52      �� $4��./IS_Bolnica;component/Images/greenscissors.png��6   $��84��6T   $��48��6_   53      54      �� 55      $
��Left=�6B   $��	0,270,0,0q�6]   $	��Top=�6p   $	��100��6�   $��51��6�   ��6   �� $ NotificationCommand���6�   Z� ��6�   Z� .��56      �� .+�57      �� $.��(/IS_Bolnica;component/Images/message.png��6   $��84��6N   $��48��6Y   58      59      �� 5:      $
��Left=�6@   $��	0,350,0,0q�6[   $	��Top=�6n   $	��100��6�   $��51��6�   ��6   �� $ MedicationCommand���6�   Z� ��6�   Z� .��5;      �� .+�5<      �� $/��)/IS_Bolnica;component/Images/pharmacy.png��6   $��84��6O   $��48��6Z   5=      5>      5?      �� 5@   
   $
��Left=�67   $��0,96,0,0q�6R   $	��Top=�6d   $	��100��6|   $��51��6�   $��1��6�   ��6   �� $ ChartCommand���6�   Z� ��6�   Z� .��5A      �� .+�5B      �� $1��+/IS_Bolnica;component/Images/chartgreen.png��6   $��84��6M   $��48��6X   5C      5D      �� 5E   
   $
��Left=�68   $��	0,337,0,0q�6S   $	��Top=�6f   $	��100��6~   $��51��6�   $��1��6�   ��6   �� $ LogoutCommand���6�   Z� ��6�   Z� .��5F      �� .+�5G      �� $.��(/IS_Bolnica;component/Images/singout.png��6   $��84��6J   $��48��6U   5H      5I      �� 5J   
   $
��Left=�6:   $��	0,270,0,0q�6U   $	��Top=�6h   $	��100��6�   $��51��6�   $��1��6�   ��6   �� $ SettingsCommand���6�   Z� ��6�   Z� .��5K      �� .+�5L      �� $/��)/IS_Bolnica;component/Images/settings.png��6   $��84��6K   $��48��6V   5M      5N      5O      5P      