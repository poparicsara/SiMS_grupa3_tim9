   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:IS_Bolnica.PatientPagesIS_Bolnica.PatientPages  5      <    6IS_Bolnica.GUI.Patient.View.EvaluationsForAppointments   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:IS_Bolnica.PatientPages     5        N� Title$   EvaluationsForAppointments��5	      .��5      � .+�5   
    � -   5        $��
StartFrame��5   i     � NavigationUIVisibility$ Hidden=�6   $	��470��60   $	��Top=�6=   $��
1,0,-0.2,0q�6U   $
��Left=�6{   $	��689��6�   �� 5   
   $��549,33,22.8,390.4q�6=   
���������6   ��  �� Path$ BackButtonCommand�.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��/PatientPages/back.png��6   $
��Fill=�68   $��30��6G   $��36��6S   �� 5      $
��Back��6   $��16(�6'   $
��Left=�65   $��27��6P   $	��Top=�6\   $��48��6t   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $*��$EvaluationsOfAppointmentsDataBinding��5         AutoGenerateColumns .  $	��258��5      $	��621��5         ColumnHeaderHeight$ 30Q�5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 141.2 5      $��15(�5      $��Center=�5         
IsReadOnly . $��Center=�5      $��45,173,22.8,39.4q�6&   ��5      �� $ PatientEvaluations� � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader	 �� 
TargetType
 �� Property �� Value��%  '        �� 5      "	  6   .�5       �� 
 � �� �	#FF4E8E7363   �� 5!      
 � ��$ Center=�6C   �� 5"      
 � ��$ 30��6/   �� 5#      
 � ��$ 1q�68   �� 5$      
 � ��
 �   �64   �� 5%      
 � ��$
 Bold"�63   5&      5'         Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ Ime(lekara)��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *Doctor.Name+  5*      $ Prezime(lekara)��6%    6>   �� *Doctor.Surname+  5+      $ Ocena��6%    64   �� *
Assessment+  5,         Width$ 197.4 6%   $ Komentar��64    6F   �� *	Comment+5/      �� 50   
   $'��!Vaše ocene dosadašnjih pregleda��6   $��26(�6:   $
��Left=�6H   $��54��6c   $��
134,60,0,0q�6o   $	��Top=�6�   $	��392��6�   �� 51   
   $��/PatientPages/nasLogo.jpg��6   $
��Fill=�63   $��24,10,609.8,404.4q�6B   �� 52   
   $��Zdravo bolnica��6   $
��Left=�6)   $��27��6D   $��	10,66,0,0q�6P   $	��Top=�6c   $��96��6{   �� 53   
   $ 
Horizontal=�6   $
��Left=�6.   $��33��6I   $	��Top=�6U   $	��196��6m   $��
45,140,0,0q�6y   .+�54      �� $��/PatientPages/search.jpg��6   $
��Fill=�66   $��33��6E   $��46��6Q   $��
0,0,0,-0.2q�6]   �� 55      -   5        $��	SearchBox��55   X   $��20(�6*   $��
0,0,0,-0.2q�68   $	��150��6L   ��56      �� $ 
SearchText� �� Mode$ OneWayToSource=�.��57       J� InputBindings 58      �� 59      
 �� Key$ Enter��6�    �� Command 6!   �� $ SearchCommand� �� CommandParameter 6H   ��  �� ElementName$* $EvaluationsOfAppointmentsDataBinding��6�   .��5:   )   5;      5<      5=      5>      