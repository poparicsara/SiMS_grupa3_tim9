   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:IS_Bolnica.SecretaryIS_Bolnica.Secretary  5      'clr-namespace:IS_Bolnica
IS_Bolnica  5      .    (IS_Bolnica.GUI.Secretary.View.DoctorList   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:IS_Bolnica.Secretary     5      'nsclr-namespace:IS_Bolnica     5        N� Title$  
DoctorList��5
      .��5      � .+�5   
   �� 
�������
�������$
��Left=�6]   $	��Top=�6x   $��48��6�   $��	10,10,0,0q�6�   $��48��6�   ��6$   ��  �� Path$ BackCommand�.��5      �� .+�5      �� $h��bC:\Users\Nikolina Pavkovic\Documents\GitHub\SiMS_grupa3_tim9\IS_Bolnica\IS_Bolnica\Images\undo.jpg��6   $��46��6�   $��41��6�    J� RenderTransformOrigin$ 	0.543,0.5&�6�   5      5      �� 5   
   $��20(�6(   
��� � �$
��Bold"�6I   $
��Left=�6[   $	��Top=�6v   $��
100,14,0,0q�6�   $��35��6�   $	��241��6�   ��6      IS_Bolnica.LocExtension  *Logo+6�   �� 5   
   -   5         ��Name$ nasLogo��5      $
��Left=�6!   $��48��6<   $��
366,10,0,0q�6H   $	��Top=�6\   $��48��6t   $k��eC:\Users\Nikolina Pavkovic\Documents\GitHub\SiMS_grupa3_tim9\IS_Bolnica\IS_Bolnica\Images\nasLogo.jpg��6   �� 5   
   $
��Bold"�61   
��� � �$��24(�6W   $
��Left=�6e   $	��Top=�6�   $��	10,69,0,0q�6�   $	��188��6�   $��37��6�   ��6     *DoctorsButton+6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DoctorListGrid��5   c      HeadersVisibility$ Column=�6H      AutoGenerateColumns .     SelectionMode$ Single=�6�      
IsReadOnly . $��Stretch=�6�   $��10,111,10.4,184.4q�6
  $��Stretch=�6%  	   GridLinesVisibility$	 Vertical=�6A  ��6{   �� $ DoctorListGrid�
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 6[      Header 6%     *
NameHeader+1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *Name+6[     5      $	 103 6a    6%     *SurnameHeader+ 6E   �� *	Surname+6a     5      $	 103 6Y    6%     *
JMBGHeader+ 6B   �� *Id+6Y     5      $	 106 6c    6%     *UsernameHeader+ 6F   �� *
Username+6c   5      �� 5   
   $
��Bold"�6\   ���	#FF15285D
����������	#FF425431$
��Left=�6�   $��
10,583,0,0q�6�   $	��Top=�6�   $	��401��6�   $��30��6  ��6     *AddShiftButton+��63   �� $ AddShiftCommand�6  �� 5   
   $
��Bold"�6b   ���	#FF15285D
����������	#FF425431$
��Left=�6�   $��
10,633,0,0q�6�   $	��Top=�6�   $	��401��6�   $ 0.189,0.889&�6	  $��30��6-  ��6     *AddVacationButton+��66   �� $ AddVacationCommand�6-  �� 5   
   -   5         ��Name$ pretraziBox��5      $
��Left=�6'   $��23��6B   $��
250,78,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��155��6�   6�   5!      5"      