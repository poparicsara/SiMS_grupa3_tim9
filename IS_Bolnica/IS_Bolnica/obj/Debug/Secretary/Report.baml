   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:IS_Bolnica.SecretaryIS_Bolnica.Secretary  5      !    IS_Bolnica.Secretary.Report   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:IS_Bolnica.Secretary     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  Report��5
      .��5      � .+�5   
   �� -   5        
�������
�������$
��Left=�5   8   $	��Top=�6S   $��48��6k   $��	10,10,0,0q�6v   $��48��6�   .��5      �� .+�5      �� $h��bC:\Users\Nikolina Pavkovic\Documents\GitHub\SiMS_grupa3_tim9\IS_Bolnica\IS_Bolnica\Images\undo.jpg��6   $��46��6�   $��41��6�    J� RenderTransformOrigin$ 	0.543,0.5&�6�   5      5      �� 5   
   -   5        
�������$
��Left=�5   $   $	��Top=�6?   $��48��6W   $��
365,10,0,0q�6b   $��48��6v   .��5      �� .+�5      �� $m��gC:\Users\Nikolina Pavkovic\Documents\GitHub\SiMS_grupa3_tim9\IS_Bolnica\IS_Bolnica\Images\printIcon.png��6   $��46��6�   $��41��6�   $ 	0.543,0.5&�6�   5      5      � 5   
   -   5         �Name$ report��5      .+�5      �� $%��Izveštaj zauzetosti prostorija��6   $
��Bold"�6=   $��20(�6O   $
��Left=�6]   $��	75,26,0,0q�6x   $	��Top=�6�   �� 5   
    �� TextAlignment$ Right=�6   $
��Left=�6*   $��212,107,0,0q�6E   $
��Wrap=�6Z   $	��Top=�6n   $��68��6�   $	��192��6�   �� 6�   $�Trg Dositeja Obra��6�   �� 6�   $�do��6�   �� 6�   $�v��6�   �� 6�   $�i��6�   �� 6�   $�ća 6, ��6�   �� 6   $�Novi Sad��6  �� 6  �� 6"  $�PDBV broj: 164654789��6&  �� 6D  �� 6P  $$�Žiro račun: 160-87965418-125��6T  �� 6z  �� 6�  $�tel: +381 21 489 2660��6�  6�  �� 5   
   $
��Bold"�6   $ Right=�6&   $
��Left=�6<   $��
259,90,0,0q�6W   $
��Wrap=�6k   $	��Top=�6   $��17��6�   $	��145��6�   $��KORPORACIJA ZDRAVO��6�   �� 5   
   -   5         ��Name$ nasLogo��5      $
��Left=�6!   $��95��6<   $��	16,64,0,0q�6H   $	��Top=�6[   $��91��6s   $N��HC:\Users\Nikolina Pavkovic\Documents\GitHub\SiMS_grupa3_tim9/nasLogo.jpg��6~   &   System.Windows.Controls.DataGrid  5      -   5          Name$ 
RoomReport��5   2      HeadersVisibility$ Column=�6      AutoGenerateColumns .     SelectionMode$ Single=�6�   	   
IsReadOnly	 . $��Stretch=�6�   $��10,181,9.4,130.4q�6�   $��Stretch=�6�   
   GridLinesVisibility$

 None=�6  ��6F   ��  �� Path$ ReportAppointments�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 SOBA��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *	Room.Id+6O     5       $ DOKTOR��6%   $ 70 6X    65   �� *Doctor.Surname+6X     5!      $ POČETAK TERMINA��6%   $	 142 6\    6>   �� *	StartTime+6\     5"      $ KRAJ TERMINA��6%   $	 142 6W    6;   �� *	EndTime+6W   5$      �� 5%   
   $A��;___________________________________________________________��6   $
��Left=�6V   $	��Top=�6q   $��240,625,0,0q�6�   $	��160��6�   �� 5&   
   $&�� (M.P.)          potpis sekretara��6   $
��Left=�6;   $	��Top=�6V   $��240,655,0,0q�6n   $	��160��6�   5'      5(      5+      