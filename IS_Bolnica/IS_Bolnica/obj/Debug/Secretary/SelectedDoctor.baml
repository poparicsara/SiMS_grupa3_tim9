   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:IS_Bolnica
IS_Bolnica  5      ;"clr-namespace:IS_Bolnica.SecretaryIS_Bolnica.Secretary  5      )    #IS_Bolnica.Secretary.SelectedDoctor   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'nsclr-namespace:IS_Bolnica     5      4local"clr-namespace:IS_Bolnica.Secretary     5        N� Title$  SelectedDoctor��5
      .��5      � .+�5   
   �� -   5        
�������
�������$
��Left=�5   8   $	��Top=�6S   $��48��6k   $��	10,10,0,0q�6v   $��48��6�   .��5      �� .+�5      �� $h��bC:\Users\Nikolina Pavkovic\Documents\GitHub\SiMS_grupa3_tim9\IS_Bolnica\IS_Bolnica\Images\undo.jpg��6   $��46��6�   $��41��6�    J� RenderTransformOrigin$ 	0.543,0.5&�6�   5      5      �� 5   
   $��20(�6)   
��� � �$
��Bold"�6J   $
��Left=�6\   $	��Top=�6w   $��
100,14,0,0q�6�   $��35��6�   $	��261��6�   ��6      IS_Bolnica.LocExtension  *Logo+6�   �� 5   
   -   5         ��Name$ nasLogo��5      $
��Left=�6!   $��48��6<   $��
366,10,0,0q�6H   $	��Top=�6\   $��48��6t   $k��eC:\Users\Nikolina Pavkovic\Documents\GitHub\SiMS_grupa3_tim9\IS_Bolnica\IS_Bolnica\Images\nasLogo.jpg��6   �� 5   
   $
��Bold"�62   
��� � �$��24(�6X   $
��Left=�6f   $	��Top=�6�   $��	10,71,0,0q�6�   $	��102��6�   $��48��6�   ��6     *DoctorsProfile+6�   �� 5   
   -   5         ��Name$ doctorNameSurnameLabel��5      $
��Bold"�61   ���	#FF15285D$��20(�6[   $
��Left=�6i   $	��Top=�6�   $��
116,75,0,0q�6�   $	��245��6�   $��48��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	ShiftList��5   .      HeadersVisibility$ Column=�6      AutoGenerateColumns .     SelectionMode$ Single=�6]      
IsReadOnly . $��Stretch=�6�   $��10,111,10.4,386.4q�6�   $��Stretch=�6�   	   GridLinesVisibility$	 Vertical=�6�   
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6e      Header 6%     *
ShiftStart+1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *ShiftStartDate+6e     5      $	 150 6a    6%     *
ShiftEnd+ 6@   �� *ShiftEndDate+6a     5      $	 100 6_    6%     *	ShiftType+ 6A   �� *	ShiftType+6_   5      �� 5   
   $
��Bold"�6   $��Vacations/free days:��6#   $��15(�6B   $
��Left=�6P   $	��Top=�6k   $��
12,353,0,0q�6�   $	��245��6�   $��48��6�     5   
   -   5        $ VacationList��5   .   $ Column=�6    .  $ Single=�6`    . $��Stretch=�6�   $��10,385,10.4,112.4q�6�   $��Stretch=�6�   $	 Vertical=�6�   
 5         5!      $	 200 6h    6%     *
ShiftStart+ 6B   �� *VacationStartDate+6h     5"      $	 200 6d    6%     *
ShiftEnd+ 6@   �� *VacationEndDate+6d   5$      �� 5%   
   -   5        $
��Bold"�5%   6   ���	#FF15285D
����������	#FF425431$
��Left=�6�   $��
10,624,0,0q�6�   $	��Top=�6�   $	��401��6�   $��30��6�   ��6     *DeleteShiftButton+6�   �� 5&   
   -   5        $
��Bold"�5&   9   ���	#FF15285D
����������	#FF425431$
��Left=�6�   $��
10,664,0,0q�6�   $	��Top=�6�   $	��401��6�   $ 0.189,0.889&�6�   $��30��6  ��6     *DeleteVacationButton+6  5'      5(      