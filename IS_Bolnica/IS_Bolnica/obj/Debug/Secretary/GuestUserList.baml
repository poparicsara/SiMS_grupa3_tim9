   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:IS_Bolnica
IS_Bolnica  5      ;"clr-namespace:IS_Bolnica.SecretaryIS_Bolnica.Secretary  5      (    "IS_Bolnica.Secretary.GuestUserList   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'nsclr-namespace:IS_Bolnica     5      4local"clr-namespace:IS_Bolnica.Secretary     5        N� Title$  GuestUserList��5
      .��5      � .+�5   
   �� -   5        
�������
�������$
��Left=�5   8   $	��Top=�6S   $��48��6k   $��	10,10,0,0q�6v   $��48��6�   .��5      �� .+�5      �� $h��bC:\Users\Nikolina Pavkovic\Documents\GitHub\SiMS_grupa3_tim9\IS_Bolnica\IS_Bolnica\Images\undo.jpg��6   $��46��6�   $��41��6�    J� RenderTransformOrigin$ 	0.543,0.5&�6�   5      5      �� 5   
   $��20(�6(   
��� � �$
��Bold"�6I   $
��Left=�6[   $	��Top=�6v   $��
100,14,0,0q�6�   $��35��6�   $	��261��6�   ��6      IS_Bolnica.LocExtension  *Logo+6�   �� 5   
   -   5         ��Name$ nasLogo��5      $
��Left=�6!   $��48��6<   $��
366,10,0,0q�6H   $	��Top=�6\   $��48��6t   $k��eC:\Users\Nikolina Pavkovic\Documents\GitHub\SiMS_grupa3_tim9\IS_Bolnica\IS_Bolnica\Images\nasLogo.jpg��6   �� 5   
   -   5        $
��Bold"�5      ���	#FF15285D
����������	#FF425431$
��Left=�6|   $��
10,632,0,0q�6�   $	��Top=�6�   $	��404��6�   $��30��6�   ��6e     *Add+6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ guestUsersGrid��5   .      HeadersVisibility$ Column=�6      AutoGenerateColumns .     SelectionMode$ Single=�6�      
IsReadOnly . $��Stretch=�6�   $��10,111,10,103.8q�6�   $��Stretch=�6�      GridLinesVisibility$ Vertical=�6  ��6F   �� *
GuestUsers+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 150 6g      Header 6%     *SystemNameHeader+1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *
SystemName+6g     5      $	
 245 6j    6%     *InjuryHeader+ 6D   �� *InjuryDescription+6j   5      �� 5   
   -   5        $
��Bold"�5      ���	#FF15285D
����������	#FF425431$
��Left=�6   $��
10,672,0,0q�6�   $	��Top=�6�   $	��404��6�   $��30��6�   ��6e     *Delete+6�   �� 5   
   $
��Bold"�6/   
��� � �$��20(�6U   $
��Left=�6c   $	��Top=�6~   $��	10,69,0,0q�6�   $	��241��6�   $��37��6�   ��6     *GuestButton+6�   �� 5   
   -   5         ��Name$ pretraziBox��5      $
��Left=�6'   $��23��6B   $��
250,78,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��155��6�   6�   5       5!      