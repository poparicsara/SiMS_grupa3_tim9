   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:IS_Bolnica.SecretaryIS_Bolnica.Secretary  5      'clr-namespace:IS_Bolnica
IS_Bolnica  5      1    +IS_Bolnica.Secretary.UrgentOperationOptions   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:IS_Bolnica.Secretary     5      'nsclr-namespace:IS_Bolnica     5        N� Title$  UrgentOperationOptions��5
      .��5      � .+�5   
   �� -   5        $
��Left=�5      $	��Top=�6,   $��48��6D   $��	10,10,0,0q�6O   $��48��6b   .��5      �� .+�5      �� $h��bC:\Users\Nikolina Pavkovic\Documents\GitHub\SiMS_grupa3_tim9\IS_Bolnica\IS_Bolnica\Images\undo.jpg��6   $��46��6�   $��41��6�    J� RenderTransformOrigin$ 	0.543,0.5&�6�   5      5      �� 5   
   $��20(�6(   
��� � �$
��Bold"�6I   $
��Left=�6[   $	��Top=�6v   $��
100,14,0,0q�6�   $��35��6�   $	��248��6�   ��6      IS_Bolnica.LocExtension  *Logo+6�   �� 5   
   -   5         ��Name$ nasLogo��5      $
��Left=�6!   $��48��6<   $��
366,10,0,0q�6H   $	��Top=�6\   $��48��6t   $k��eC:\Users\Nikolina Pavkovic\Documents\GitHub\SiMS_grupa3_tim9\IS_Bolnica\IS_Bolnica\Images\nasLogo.jpg��6   �� 5   
   $
��Bold"�6,   
��� � �$��24(�6R   $
��Left=�6`   $	��Top=�6{   $��	10,69,0,0q�6�   $	��246��6�   $��46��6�   ��6     *
ChooseOp+6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ OperationOptions��5         AutoGenerateColumns .     SelectionMode$ Extended=�6I      
IsReadOnly . $��Stretch=�6t   $��12,120,8,133.8q�6�   $��Stretch=�6�      GridLinesVisibility$ Vertical=�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 70 6g   
   Header
 6%     *DoctorHeader+1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   �� *Doctor.Surname+6g     5      $		 100 6`   
 6%     *
DateHeader+ 6B   �� *	StartTime+6`     5      $	 50 6d   
 6%     *PatJMBGHeader+ 6E   �� *
Patient.Id+6d     5      $
 Guest��6%   $	 50 6]    64   �� *GuestUser.SystemName+6]     5      $	
 Min��6%   $	 40 6U    62   �� *DurationInMins+6U     5      $
 Postpone��6%   $		 100 6Y    67   �� *PostponedDate+6Y   5      �� 5    
   -   5        $
��Bold"�5    /   ���	#FF15285D
�������$
��Left=�6k   $��
40,635,0,0q�6�   $	��Top=�6�   $	��342��6�   $��35��6�   ��6     *
ScheduleOp+6�   5"      5#      