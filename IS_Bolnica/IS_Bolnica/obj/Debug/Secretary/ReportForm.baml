   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:IS_Bolnica.SecretaryIS_Bolnica.Secretary  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      'clr-namespace:IS_Bolnica
IS_Bolnica  5	      %    IS_Bolnica.Secretary.ReportForm   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:IS_Bolnica.Secretary     5      9System&clr-namespace:System;assembly=mscorlib     5      'nsclr-namespace:IS_Bolnica     5	        N� Title$  
ReportForm��5      .��5      � .+�5   
   �� -   5        $
��Left=�5      $	��Top=�6,   $��48��6D   $��	10,10,0,0q�6O   $��48��6b   .��5      �� .+�5      �� $��../Images/undo.jpg��6   $��45��64   $��46��6?    J� RenderTransformOrigin$ 	0.543,0.5&�6K   5      5      �� 5   
   $��20(�6(   
��� � �$
��Bold"�6I   $
��Left=�6[   $	��Top=�6v   $��
100,14,0,0q�6�   $��35��6�   $	��261��6�   ��6      IS_Bolnica.LocExtension  *Logo+6�   �� 5   
   -   5         ��Name$ nasLogo��5      $��../Images/nasLogo.jpg��6!   $
��Left=�6@   $��48��6[   $��
366,10,0,0q�6g   $	��Top=�6{   $��48��6�   �� 5   
   $	��Top=�6   $��
40,160,0,0q�6(   $
��Left=�6<   ��6W     *	RoomLabel+�� 5   
   $	��Top=�6   $��
40,220,0,0q�6(   $
��Left=�6<   ��6W     *DateFromLabel+�� 5   
   $	��Top=�6   $��
40,280,0,0q�6(   $
��Left=�6<   ��6W     *DateToLabel+(  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dateBoxFrom��5      $
��Left=�6*   $��200,220,0,0q�6E   $	��Top=�6Z   $	��182��6r   �� 5   
   $
��Bold"�6.   
��� � �$��24(�6T   $
��Left=�6b   $	��Top=�6}   $��	10,75,0,0q�6�   $	��372��6�   $��48��6�   ��6     *
ReportForm+6�   �� 5   
   -   5         ��Name$ roomBox��5      $	��182��6$   $	��Top=�60   $��200,160,0,0q�6H   $
��Left=�6]     5   
   -   5        $ 	dateBoxTo��5      $
��Left=�6(   $��200,280,0,0q�6C   $	��Top=�6X   $	��182��6p   �� 5   
   -   5        $
��Bold"�5   7   ���	#FF15285D
�������$
��Left=�6s   $��
40,600,0,0q�6�   $	��Top=�6�   $	��342��6�   $��35��6�   ��6     *CreateReportButton+6�   5!      5"      