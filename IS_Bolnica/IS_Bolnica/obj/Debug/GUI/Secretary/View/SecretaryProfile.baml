   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:IS_Bolnica.SecretaryIS_Bolnica.Secretary  5      'clr-namespace:IS_Bolnica
IS_Bolnica  5      4    .IS_Bolnica.GUI.Secretary.View.SecretaryProfile   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:IS_Bolnica.Secretary     5      'nsclr-namespace:IS_Bolnica     5        N� Title$  SecretaryProfile��5
      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��0* �6    � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   .+�5   
    � -   5          �Name$ Frame��5      $��0,0,0.4,0.4q�6   �� 5   
   
�������
�������$
��Left=�6b   $	��Top=�6}   $��48��6�   $��	10,10,0,0q�6�   $��48��6�   ��6   ��  �� Path$ ActionBarCommand�.��5      �� .+�5      �� $q��kC:\Users\Nikolina Pavkovic\Documents\GitHub\SiMS_grupa3_tim9\IS_Bolnica\IS_Bolnica\Images\actionBarIcon.png��6   $��46��6�   $��41��6�    J� RenderTransformOrigin$ 	0.543,0.5&�6�   5      5      �� 5   
   
�������
�������$
��Left=�6_   $	��Top=�6z   $��48��6�   $��	93,70,0,0q�6�   $��48��6�   ��6   �� $ LogOutCommand�.��5      �� .+�5      �� $j��dC:\Users\Nikolina Pavkovic\Documents\GitHub\SiMS_grupa3_tim9\IS_Bolnica\IS_Bolnica\Images\logout.png��6   $��46��6�   $��41��6�   $ 	0.543,0.5&�6�   5      5      �� 5   
   $��20(�6(   
��� � �$
��Bold"�6I   $
��Left=�6[   $	��Top=�6v   $��
100,14,0,0q�6�   $��35��6�   $	��255��6�   ��6      IS_Bolnica.LocExtension  *Logo+6�   �� 5    
   -   5         ��Name$ nasLogo��5       $
��Left=�6!   $��48��6<   $��
360,10,0,0q�6H   $	��Top=�6\   $��48��6t   $.��(/IS_Bolnica;component/Images/nasLogo.jpg��6   �� 5!   
   $��15(�6   $
��Bold"�6   $
��Left=�6M   $��
40,140,0,0q�6h   $	��Top=�6|   $ -0.051,-0.052&�6�   $	��140��6�   $��28��6�   ��60     *	NameLabel+6�   �� 5"   
   $��15(�6   $
��Bold"�6   $
��Left=�6P   $��
40,180,0,0q�6k   $	��Top=�6   $ -0.051,-0.052&�6�   $	��140��6�   $��28��6�   ��60     *SurnameLabel+6�   �� 5#   
   $��15(�6   $
��Bold"�6   $
��Left=�6Q   $��
40,220,0,0q�6l   $	��Top=�6�   $ -0.051,-0.052&�6�   $	��140��6�   $��28��6�   ��60     *UsernameLabel+6�   �� 5$   
   $��15(�6   $
��Bold"�6   $
��Left=�6H   $��
40,260,0,0q�6c   $	��Top=�6w   $ -0.051,-0.052&�6�   $	��140��6�   $��28��6�   ��60     *jmbg+6�   �� 5%   
   $��15(�6   $
��Bold"�6   $
��Left=�6R   $��
40,300,0,0q�6m   $	��Top=�6�   $ -0.051,-0.052&�6�   $	��140��6�   $��28��6�   ��60     *DateBirthLabel+6�   �� 5&   
   $��15(�6   $
��Bold"�6   $
��Left=�6N   $��
40,380,0,0q�6i   $	��Top=�6}   $ -0.051,-0.052&�6�   $	��140��6�   $��28��6�   ��60     *
EmailLabel+6�   �� 5'   
   $��15(�6   $
��Bold"�6   $
��Left=�6R   $��
40,340,0,0q�6m   $	��Top=�6�   $ -0.051,-0.052&�6�   $	��140��6�   $��28��6�   ��60     *TelephoneLabel+6�   �� 5(   
   $��15(�6   $
��Bold"�6   $
��Left=�6O   $��
40,420,0,0q�6j   $	��Top=�6~   $ -0.051,-0.052&�6�   $	��140��6�   $��28��6�   ��60     *AdressLabel+6�   �� 5)   
   $��15(�6   $
��Bold"�6   $
��Left=�6M   $��
40,460,0,0q�6h   $	��Top=�6|   $ -0.051,-0.052&�6�   $	��140��6�   $��28��6�   ��60     *	CityLabel+6�   �� 5*   
   $��15(�6   $
��Bold"�6   $
��Left=�6P   $��
40,500,0,0q�6k   $	��Top=�6   $ -0.051,-0.052&�6�   $	��140��6�   $��28��6�   ��60     *CountryLabel+6�   �� 5+   
   -   5         ��Name$ imeLabel��5+      $
��Left=�6E   $��232,140,0,0q�6`   $	��Top=�6u   $ -0.051,-0.052&�6�   $	��170��6�   $��28��6�   ��6"   �� $ 	NameLabel�6�   �� 5,   
   -   5        $ prezimeimeLabel��5,      $
��Left=�6O   $��232,180,0,0q�6j   $	��Top=�6   $ -0.051,-0.052&�6�   $	��170��6�   $��28��6�   ��6)   �� $ SurnameLabel�6�   �� 5-   
   -   5        $ usernameLabel��5-      $
��Left=�6N   $��232,220,0,0q�6i   $	��Top=�6~   $ -0.051,-0.052&�6�   $	��170��6�   $��28��6�   ��6'   �� $ UsernameLabel�6�   �� 5.   
   -   5        $ 	JMBGLabel��5.      $
��Left=�6F   $��232,260,0,0q�6a   $	��Top=�6v   $ -0.051,-0.052&�6�   $	��170��6�   $��28��6�   ��6#   �� $ 	JMBGLabel�6�   �� 5/   
   -   5        $ 	dateLabel��5/      $
��Left=�6F   $��232,300,0,0q�6a   $	��Top=�6v   $ -0.051,-0.052&�6�   $	��170��6�   $��28��6�   ��6#   �� $ 	DateLabel�6�   �� 50   
   -   5        $ 
emailLabel��50      $
��Left=�6H   $��232,380,0,0q�6c   $	��Top=�6x   $ -0.051,-0.052&�6�   $	��170��6�   $��28��6�   ��6$   �� $ 
EmailLabel�6�   �� 51   
   -	   5        $ telephoneLabel��51      $
��Left=�6L   $��232,340,0,0q�6g   $	��Top=�6|   $ -0.051,-0.052&�6�   $	��170��6�   $��28��6�   ��6(   �� $ 
PhoneLabel�6�   �� 52   
   -
   5        $ adressLabel��52      $
��Left=�6K   $��232,420,0,0q�6f   $	��Top=�6{   $ -0.051,-0.052&�6�   $	��170��6�   $��28��6�   ��6%   �� $ AddressLabel�6�   �� 53   
   -   5        $ 	cityLabel��53      $
��Left=�6F   $��232,460,0,0q�6a   $	��Top=�6v   $ -0.051,-0.052&�6�   $	��170��6�   $��28��6�   ��6#   �� $ 	CityLabel�6�   �� 54   
   -   5        $ countryLabel��54      $
��Left=�6L   $��232,500,0,0q�6g   $	��Top=�6|   $ -0.051,-0.052&�6�   $	��170��6�   $��28��6�   ��6&   �� $ CountryLabel�6�   �� 55   
   $
��Bold"�60   
��� � �$��24(�6V   $
��Left=�6d   $	��Top=�6   $��	10,75,0,0q�6�   $��83��6�   $��48��6�   ��6     *ProfileLabel+6�   56      58      