   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:IS_Bolnica.DoctorUIIS_Bolnica.DoctorUI  5   	   '    !IS_Bolnica.DoctorUI.InvoiceWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:IS_Bolnica.DoctorUI     5   	     � Title$  InvoiceWindow��5   	   $	��768��6   $
��1024��6,    � 
ResizeMode$ NoResize=�69    � WindowStartupLocation$ CenterScreen=�6O   .��5	      � .+�5
   
   �� $#��Izveštaj o lekarskom receptu��6   $
��Left=�67   $��
361,23,0,0q�6R   $	��Top=�6f   $��41��6~   $	��296��6�   $��20(�6�   $
��Bold"�6�   �� 5   
   $��"Zdravo" korporacija
��6   $
��Left=�6C   $��
673,89,0,0q�6^   $	��Top=�6r   $��35��6�   $	��190��6�   $��14(�6�   $
��Bold"�6�   �� 5   
   $+��%Trg Dositeja Obradovića 6, Novi Sad
��6   $
��Left=�6C   $��588,104,0,0q�6^   $	��Top=�6s   $��32��6�   $	��275��6�   $��14(�6�   �� 5   
   $%��Ime i prezime osiguranog lica:
��6   $
��Left=�6>   $��135,173,0,0q�6Y   $	��Top=�6n   $��35��6�   $	��242��6�   $��13(�6�   $
��Bold"�6�   �� 5   
   $��Datum rođenja:
��6   $
��Left=�6.   $��135,213,0,0q�6I   $	��Top=�6^   $��35��6v   $	��242��6�   $��13(�6�   $
��Bold"�6�   �� 5   
   $!��Adresa i mesto stanovanja:
��6   $
��Left=�6:   $��135,248,0,0q�6U   $	��Top=�6j   $��35��6�   $	��242��6�   $��13(�6�   $
��Bold"�6�   �� 5   
   $��JMBG:
��6   $
��Left=�6%   $��135,288,0,0q�6@   $	��Top=�6U   $��35��6m   $	��242��6y   $��13(�6�   $
��Bold"�6�   �� 5   
   $"��Broj zdravstvene knjižice:
��6   $
��Left=�6:   $��135,328,0,0q�6U   $	��Top=�6j   $��35��6�   $	��242��6�   $��13(�6�   $
��Bold"�6�   �� 5   
   $��Datum pregleda:
��6   $
��Left=�6/   $��135,368,0,0q�6J   $	��Top=�6_   $��35��6w   $	��242��6�   $��13(�6�   $
��Bold"�6�   �� 5   
   $��Datum izdavanja recepta:
��6   $
��Left=�68   $��135,408,0,0q�6S   $	��Top=�6h   $��35��6�   $	��242��6�   $��13(�6�   $
��Bold"�6�   �� 5   
   $��Dijagnoza:
��6   $
��Left=�6*   $��135,448,0,0q�6E   $	��Top=�6Z   $��35��6r   $	��242��6~   $��13(�6�   $
��Bold"�6�   �� 5   
   $��Lek/terapija:
��6   $
��Left=�6-   $��135,549,0,0q�6H   $	��Top=�6]   $��35��6u   $	��242��6�   $��13(�6�   $
��Bold"�6�   �� 5   
   $l��f______________________________________________________________________
               (potpis lekara)��6   $
��Left=�6�   $��673,627,0,0q�6�   $	��Top=�6�   $��66��6�   $	��301��6�   $��11(�6�   �� 5   
   -   5        $��
patientTxt��5      $
��Left=�6%   $��23��6@   $��414,178,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��168��6�    �� 
IsReadOnly . ��6�   Z� 6�   �� 5   
   -   5        $��dateOfBirthTxt��5      $
��Left=�6(   $��23��6C   $��414,213,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��168��6�    . ��6�   Z� 6�   �� 5   
   -   5        $��
addressTxt��5      $
��Left=�6$   $��23��6?   $��414,252,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��168��6�    . ��6�   Z� 6�   �� 5   
   -   5        $��idTxt��5      $
��Left=�6   $��23��6:   $��414,288,0,0q�6F   $
 Wrap=�6[   $	��Top=�6o   $	��168��6�    . ��6�   Z� 6�   �� 5   
   -   5        $��healthCardTxt��5      $
��Left=�6'   $��23��6B   $��414,328,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��168��6�    . ��6�   Z� 6�   �� 5   
   -   5        $��examinationDateTxt��5      $
��Left=�6-   $��23��6H   $��414,368,0,0q�6T   $
 Wrap=�6i   $	��Top=�6}   $	��168��6�    . ��6�   Z� 6�   �� 5   
   -   5        $��precriptionDateTxt��5      $
��Left=�6,   $��23��6G   $��414,408,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��168��6�    . ��6�   Z� 6�   �� 5   
   -   5        $��diagnosisTxt��5      $
��Left=�6&   $��79��6A   $��414,448,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��278��6�    . ��6�   Z� 6�   �� 5   
   -	   5        $��medTxt��5      $
��Left=�6    $��23��6;   $��414,549,0,0q�6G   $
 Wrap=�6\   $	��Top=�6p   $	��168��6�    . ��6�   Z� 6�   �� 5    
   $��(M.P)��6   $
��Left=�6    $��645,675,0,0q�6;   $	��Top=�6P   $��32��6h   $	��167��6t   �� 5!   
   -
   5        $
��Left=�5!      $��
938,28,0,0q�6,   $	��Top=�6@   $��45��6X   $��36��6|   ��6�   Z� ��6�   Z� .��5"      �� .+�5#      �� $��../Images/printer.png��6   $��30��67   $��30��6B   5$      5%      �� 5&   
   -   5        $
��Left=�5&      $��	10,23,0,0q�6,   $	��Top=�6?   $��60��6W   $��41��6b   ��6n   Z� ��6�   Z� .��5'      �� 
������ .+�5(      �� $��../Images/back.png��6   $��30��64   $��30��6?   5)      5*      5,      5-      