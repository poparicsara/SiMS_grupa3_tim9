   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:IS_Bolnica.DoctorUIIS_Bolnica.DoctorUI  5   	   l hSystem.Windows.Controls.DataVisualization.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null�rclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit)System.Windows.Controls.DataVisualization 5   	   �{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting 5   	   %    IS_Bolnica.DoctorUI.ChartWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:IS_Bolnica.DoctorUI     5   	   �DVrclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	   �DVC{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	     � Title$  ChartWindow��5
   	   $	��768��6   $
��1024��6*    � 
ResizeMode$ NoResize=�67    � WindowStartupLocation$ CenterScreen=�6M   .��5      � .+�5   
   � $
��Left=�6   $	��739��6*   $	��Top=�67   $	��100��6O   ���	#FFF1F0F0$��0q�6r   .+�5      �� -   5        $
��Left=�5      $��	0,110,0,0q�60   $	��Top=�6C   $	��100��6[   $��51��6g   ��6s   Z� ��6�   Z� .��5      �� .+�5      �� $7��1/IS_Bolnica;component/Images/greenstethoscope.png��6   $��84��6W   $��48��6b   5      5      �� 5      -   5        $
��Left=�5      $��	0,195,0,0q�61   $	��Top=�6D   $	��100��6\   $��51��6h   ��6t   Z� ��6�   Z� .��5      �� .+�5      �� $4��./IS_Bolnica;component/Images/greenscissors.png��6   $��84��6T   $��48��6_   5      5      �� 5      -   5        $
��Left=�5      $��	0,270,0,0q�61   $	��Top=�6D   $	��100��6\   $��51��6h   ��6t   Z� ��6�   Z� .��5      �� .+�5      �� $.��(/IS_Bolnica;component/Images/message.png��6   $��84��6N   $��48��6Y   5      5      �� 5      -   5        $
��Left=�5      $��	0,350,0,0q�61   $	��Top=�6D   $	��100��6\   $��51��6h   ��6t   Z� ��6�   Z� .��5      �� .+�5      �� $/��)/IS_Bolnica;component/Images/pharmacy.png��6   $��84��6O   $��48��6Z   5      5       5!      �� 5"   
   -   5        $
��Left=�5"      $��	0,430,0,0q�6,   $	��Top=�6?   $	��100��6W   $��51��6c   ��6o   Z� ��6�   Z� .��5#      �� .+�5$      �� $1��+/IS_Bolnica;component/Images/chartgreen.png��6   $��84��6M   $��48��6X   5%      5&      �� 5'   
   -   5        $
��Left=�5'      $��	0,671,0,0q�6,   $	��Top=�6?   $	��100��6W   $��51��6c   ��6o   Z� ��6�   Z� .��5(      �� .+�5)      �� $.��(/IS_Bolnica;component/Images/singout.png��6   $��84��6J   $��48��6U   5*      5+      �� 5,   
   -   5        $
��Left=�5,      $��	0,604,0,0q�6,   $	��Top=�6?   $	��100��6W   $��51��6c   ��6o   Z� ��6�   Z� .��5-      �� .+�5.      �� $/��)/IS_Bolnica;component/Images/settings.png��6   $��84��6K   $��48��6V   5/      50      � 51   
   $
��Left=�6   $��91��6*   $	��Top=�66   $
��1008��6N   ���	#FFF1F0F0$��10,0,0,0q�6r   .+�52      �� $%��Statistika pregleda i operacija��6   $
��Left=�6>   $��
110,20,0,0q�6Y   $	��Top=�6m   $	��550��6�   $��Malgun Gothic)�6�   $��36(�6�   $
��Bold"�6�   $��71��6�   �� 53      $&�� Odnos broja pregleda i operacija��6   $
��Left=�6?   $��172,140,0,-93q�6Z   $	��Top=�6q   $	��304��6�   $��Malgun Gothic)�6�   $��18(�6�   $��44��6�   $
��Bold"�6�   54      >  8System.Windows.Controls.DataVisualization.Charting.Chart  56   
   -   5        $��mcChart��56      $��178,208,94,97q�6#   ���	#FF394836$
��Bold"�6h   $��14(�6z   $��Malgun Gothic)�6�   ���	#FFF1F0F0��6Q   Z�    Series 5:      B  <System.Windows.Controls.DataVisualization.Charting.PieSeries  ?  9System.Windows.Controls.DataVisualization.Charting.Series   Title$ Broj termina��5;       
���   �H  BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   IndependentValueBinding 5:       ��  �� Path$	 Key�   DependentValueBinding 6M   �� $ Value�5;   5   5@      5C      5D      