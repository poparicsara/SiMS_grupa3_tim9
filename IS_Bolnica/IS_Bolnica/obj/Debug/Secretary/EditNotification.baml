   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:IS_Bolnica
IS_Bolnica  5      ;"clr-namespace:IS_Bolnica.SecretaryIS_Bolnica.Secretary  5      +    %IS_Bolnica.Secretary.EditNotification   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'nsclr-namespace:IS_Bolnica     5      4local"clr-namespace:IS_Bolnica.Secretary     5        N� Title$  EditNotification��5
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
��Bold"�69   
��� � �$��24(�6_   $
��Left=�6m   $	��Top=�6�   $��	10,75,0,0q�6�   $	��299��6�   $��48��6�   ��6     *EditNotificationLabel+6�   �� 5   
   $
��Left=�63   $	��Top=�6N   $��
17,142,0,0q�6f   $	��131��6z   $��26��6�   ��6     *NotifTitleLabel+6�   �� 5   
   $
��Left=�60   $	��Top=�6K   $��
17,203,0,0q�6c   $��99��6w   ��6     *ContentLabel+6w   �� 5   
   -   5         ��Name$ title��5      $
��Left=�6!   $��23��6<   $��165,145,0,0q�6H    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��231��6�   �� 5   
   -   5        $ content��5      $
��Left=�6#   $	��102��6>   $��165,203,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��231��6�   �� 5   
   -   5        $
��Bold"�5   1   ���	#FF15285D
�������$
��Left=�6m   $��
17,580,0,0q�6�   $	��Top=�6�   $	��379��6�   $��35��6�   ��6     *CancelButton+6�   �� 5   
   -   5        $
��Bold"�5   2   ���	#FF15285D
�������$
��Left=�6n   $��
17,630,0,0q�6�   $	��Top=�6�   $	��379��6�   $ 0.393,0.417&�6�   $��35��6�   ��6     *ConfirmButton+6�   �� 5   
   $
��Left=�61   $	��Top=�6L   $��
17,323,0,0q�6d   $	��131��6x   $��26��6�   ��6     *UserTypeLabel+6�   �� 5   
   -   5         ��Name$ comboBox��5      $
��Left=�6%   $��165,327,0,0q�6@   $	��Top=�6U   $	��231��6m   .@�5      �� .��6   DOKTOR5      �� 5       .��6   
PACIJENT5"      �� 5#      .��6   SVI5%      �� 5&      .��6   ODREĐENI KORISNIK/CI5(      5)      �� 5*   
   $
��Left=�6-   $	��Top=�6H   $��
17,383,0,0q�6`   $	��131��6t   $��26��6�   ��6     *	UserLabel+6�   �� 5+   
   -   5        $ idBox��5+      $
��Left=�6!   $��23��6<   $��165,383,0,0q�6H   $
 Wrap=�6]   $	��Top=�6q   $	��170��6�   �� 5,   
   -	   5        $
��Bold"�5,   .   ���	#FF15285D
�������$
��Left=�6j   $��344,385,0,0q�6�   $	��Top=�6�   $��52��6�   $ 0.5,0.5&�6�   ��6     *	AddButton+z�5-      V� 5.      .~�5/      �� �� 50      �� 51       �� Angle$ -0.811Q�6&   T� 52      53      55      �� 56   
   -
   5         ��Name$ 	idListBox��56      $
��Left=�6%   $	��100��6@   $��165,439,0,0q�6M   $	��Top=�6b   $	��170��6z   �� 57   
   -   5        $
��Bold"�57   1   ���	#FF15285D
�������$
��Left=�6m   $��344,519,0,0q�6�   $	��Top=�6�   $��52��6�   $ 0.5,0.5&�6�   ��6     *RemoveButton+z�58      V� 59      .~�5:      �� �� 5;      �� 5<      $ -0.811Q�6&   T� 5=      5>      5@      5A      5B      