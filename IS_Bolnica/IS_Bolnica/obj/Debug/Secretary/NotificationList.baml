   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:IS_Bolnica.SecretaryIS_Bolnica.Secretary  5      'clr-namespace:IS_Bolnica
IS_Bolnica  5      +    %IS_Bolnica.Secretary.NotificationList   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:IS_Bolnica.Secretary     5      'nsclr-namespace:IS_Bolnica     5        N� Title$  NotificationList��5
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
   $
��Bold"�67   
��� � �$��20(�6]   $
��Left=�6k   $	��Top=�6�   $��	10,69,0,0q�6�   $	��246��6�   $��37��6�   ��6     *NotificationsButton+6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ NotificationListGrid��5   i      HeadersVisibility$ Column=�6N      AutoGenerateColumns .     SelectionMode$ Single=�6�      
IsReadOnly . $��Stretch=�6�   $��10,111,10,142.8q�6  $��Stretch=�6.     GridLinesVisibility$ Vertical=�6J  ��6�   �� 	 �� Path$	 Notifications�
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 6]      Header 6%     *TitleHeader+1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *Title+6]     5      $	 200 6a    6%     *ContentHeader+ 6E   �� *	Content+6a     5      $	 110 6k    6%     *UserTypeHeader+ 6F   �� *notificationType+6k   5      �� 5   
   -   5        $
��Bold"�5   (   ���	#FF15285D
����������	#FF425431$
��Left=�6|   $��
10,592,0,0q�6�   $	��Top=�6�   $	��401��6�   $��30��6�   ��6     *Add+6�   �� 5   
   -   5        $
��Bold"�5   )   ���	#FF15285D
����������	#FF425431$
��Left=�6}   $��
10,632,0,0q�6�   $	��Top=�6�   $	��401��6�   $ 0.189,0.889&�6�   $��30��6  ��6     *Edit+6  �� 5   
   -   5        $
��Bold"�5   +   ���	#FF15285D
����������	#FF425431$
��Left=�6   $��
10,672,0,0q�6�   $	��Top=�6�   $	��401��6�   $ 0.475,0.167&�6�   $��30��6  ��6     *Delete+6  �� 5   
   -   5         ��Name$ pretraziBox��5      $
��Left=�6'   $��23��6B   $��
250,78,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��155��6�   6�   5!      5"      