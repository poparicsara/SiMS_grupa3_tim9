   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:IS_Bolnica.PatientPagesIS_Bolnica.PatientPages  5      7    1IS_Bolnica.PatientPages.ChoosePeriodForReportPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:IS_Bolnica.PatientPages     5        N� Title$  ChoosePeriodForReportPage��5	      .��5      � .+�5   
   �� $��Zdravo bolnica��6   $
��Left=�6)   $��27��6D   $��	10,66,0,0q�6P   $	��Top=�6c   $��93��6{   �� 5   
   $��nasLogo.jpg��6   $
��Fill=�6%   $��24,10,609.8,409.4q�64   �� 5   
   -   5        $��549,33,22.8,390.4q�5   +   
�������.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��back.png��6   $
��Fill=�6*   $��30��69   $��36��6E   �� 5      $
��Back��6   $��16(�6'   $
��Left=�65   $��27��6P   $	��Top=�6\   $��48��6t   5      5      �� 5   
   $:��4Unesite period za koji želite da dobijete izveštaj��6   $��27(�6M   $
��Left=�6[   $	��Top=�6v   $��
143,50,0,0q�6�   $	��379��6�   �� 5   
   $��dobijete izveštaj��6   $��27(�6,   $
��Left=�6:   $	��Top=�6U   $��
230,96,0,0q�6m   $	��208��6�   �� 5   
   $��Početni datum��6   $��22(�6(   $
��Left=�66   $	��Top=�6Q   $��103,198,0,0q�6i   $	��150��6~   �� 5   
   $��Krajnji datum��6   $��22(�6(   $
��Left=�66   $	��Top=�6Q   $��103,279,0,0q�6i   $	��150��6~   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��StartDatePicker��5   >   $��22(�6   $
��Left=�6#   $	��Top=�6U   $��364,201,0,0q�6m   $	��202��6�      DisplayDateStart 6�   �� *DisplayDate+ �� ElementName$ StartDatePicker��  5   
   -   5        $��EndDatePicker��5   >   $��22(�6   $
��Left=�6#   $	��Top=�6S   $��364,282,0,0q�6k   $	��202��6�    6�   �� *DisplayDate+$ EndDatePicker���� 5   
   -   5        $��364,389,178.8,33.4q�5   .   
�������.��5      �� $ 
Horizontal=�6   .+�5      �� $��incorrect.png��6   $
��Fill=�6/   $��30��6>   $��43��6J   �� 5      $��Odustani��6   $��18(�6+   $
��Left=�69   $��35��6T   $	��Top=�6`   $��83��6x   5      5      �� 5    
   -   5        $��143,389,417.8,33.4q�5    +   
�������.��5!      �� $ 
Horizontal=�6   .+�5"      �� $��correct.png��6   $
��Fill=�6-   $��30��6<   $��47��6H   �� 5#      $��Pošalji��6   $��18(�6*   $
��Left=�68   $��35��6S   $	��Top=�6_   $��61��6w    J� RenderTransformOrigin$ 0.5,0.5&�6�   5$      5%      5&      5'      