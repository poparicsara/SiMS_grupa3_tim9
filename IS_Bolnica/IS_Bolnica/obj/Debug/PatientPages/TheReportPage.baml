   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:IS_Bolnica.PatientPagesIS_Bolnica.PatientPages  5      +    %IS_Bolnica.PatientPages.TheReportPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:IS_Bolnica.PatientPages     5        N� Title$  TheReportPage��5	      .��5      � .+�5   
   �� -   5        $��562,30,9.8,393.4q�5   +   
�������.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��back.png��6   $
��Fill=�6*   $��30��69   $��36��6E   �� 5      $
��Back��6   $��16(�6'   $
��Left=�65   $��27��6P   $	��Top=�6\   $��48��6t   5      5      �� 5   
   $��562,345,3.8,92.4q�6   
�������.��5      �� $
��Left=�6   $��37��64   $ 
Horizontal=�6@   $	��Top=�6Y   $	��117��6q   .+�5      �� $��	print.png��6   $��	0,0,0,4.8q�6+   �� 5      $��Štampaj��6   $��16(�6*   $��32��68   $	��Top=�6D   5      5      �� 5   
   -   5        $��562,299,3.8,134.4q�5   /   
�������.��5      �� $
��Left=�6   $��38��64   $ 
Horizontal=�6@   $	��Top=�6Y   $	��124��6q   .+�5      �� $��download.png��6   $
��Fill=�6.   $��22��6=   $��
0,9,0,10.4q�6H   �� 5      $��Preuzmi(.pdf)��6   $��15(�60   $
��Left=�6>   $��32��6Y   $	��Top=�6e   $��99��6}   5      5      �� 5    
   -   5        $��ReportForDownload��5       $
��Left=�6.   $	��460��6I   $	��Top=�6V   $	��557��6n   .+�5!      �� $��13��6   $��
0,0,-0.2,0q�6%   �� 5"      $��nasLogo.jpg��6   $��68��6)   $��23,0,439.8,0q�65   �� 5#      $��Zdravo bolnica��6   $
��Left=�6-   $��27��6H   $	��Top=�6T   $��94��6l   $��23,0,0,0q�6w   �� 5$      $ 
Horizontal=�6   $��48��62   $��
0,0,-0.2,0q�6>   .+�5%      �� $*��$Trg Dositeja Obradovića 6, Novi Sad��6   $
��Left=�6F   $	��Top=�6a   $	��324��6y    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��28��6�   $��	10,10,0,0q�6�   �� 5&      $��	Izveštaj��6   $��28(�6+   $
��Left=�69   $	��Top=�6T   $	��103��6l   5'      �� 5(      $��tel: +381 24 489 2660��6   $
��Left=�64   $	��Top=�6O   $	��192��6g   $ 0.5,0.5&�6s   $��27��6�   $��10,0,0,0q�6�   �� 5)      $��PDV broj: 165478963��6   $
��Left=�62   $	��Top=�6M   $	��192��6e   $ 0.5,0.5&�6q   $��27��6�   $��10,0,0,0q�6�   �� 5*      $$��Žiro račun: 160-81564789-125��6   $
��Left=�6;   $	��Top=�6V   $	��192��6n   $ 0.5,0.5&�6z   $��27��6�   $��10,0,0,0q�6�   &   System.Windows.Controls.DataGrid  5+      -   5          Name$ ReportDataGrid��52         AutoGenerateColumns .  $	��216��5,      $	��539��5-         ColumnHeaderHeight$ 30Q�5.         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 135 5/      $��15(�50      $��Center=�51         
IsReadOnly . $��Center=�54      $ 0.476,0.464&�6&   $��	8,0,9.8,0q�6J    � 	Resources 55      =  7System.Windows.Controls.Primitives.DataGridColumnHeader	 �� 
TargetType
 �� Property �� Value��%  '        �� 56      "	  6   .�57      �� 
 � �� �	#FF4E8E7367   �� 58      
 � ��$ Center=�6G   �� 59      
 � ��$ 30��63   �� 5:      
 � ��$ 1q�6<   �� 5;      
 � ��
 �   �68   �� 5<      
 � ��$
 Bold"�67   5=      5>         Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn   Width$	 156 6)      Header$ Datum i vreme��65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6L   �� *	StartTime+  5A      $ Ime(lekara)��6)    6>   �� *Doctor.Name+  5B      $ Prezime(lekara)��6)    6B   �� *Doctor.Surname+  5C      $	 114 6)   $	 Tip��65    6B   �� *TypeOfAppointment+5F      5H      5J      5K      