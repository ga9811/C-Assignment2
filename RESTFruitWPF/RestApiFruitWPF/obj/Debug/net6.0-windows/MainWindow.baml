   M S B A M L   `   `   `  ����J  FRestApiFruitWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:RestApiFruitWPFRestApiFruitWPF  5   	        RestApiFruitWPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:RestApiFruitWPF     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	fruitList��5
      $	��NaN��6Q   $��143,270,207,48q�6^   $	��NaN��6v   �� 5   
   -   5         ��Name$ ProductName��5      $
��Left=�6'   $��
143,94,0,0q�6B    �� TextWrapping$
 Wrap=�6V   $
��name��6j   $	��Top=�6v   $	��120��6�   �� 5   
   -   5        $ 	ProductID��5      $
��Left=�6%   $��143,130,0,0q�6@   $
 Wrap=�6U   $��ID��6i   $	��Top=�6s   $	��120��6�   �� 5   
   -   5        $ Amount��5      $
��Left=�6"   $��143,168,0,0q�6=   $
 Wrap=�6R   $��Amount��6f   $	��Top=�6t   $	��120��6�   �� 5   
   -   5        $ Price��5      $
��Left=�6!   $��143,200,0,0q�6<   $
 Wrap=�6Q   $��Price��6e   $	��Top=�6r   $	��120��6�   �� 5   
   $)��#Fruit Database Connection with Rest��6   $
��Left=�6>   $��50��6Y   $��
143,25,0,0q�6e   $	��Top=�6y   $	��544��6�   $
��Bold"�6�   $��Center=�6�   $��24(�6�   �� 5   
   -   5         ��Name$ AddBtn��5      $	��ADD��6!   $
��Left=�6/   $��
415,88,0,0q�6J   $	��Top=�6^   $��97��6v   $
��Bold"�6�   6�   �� 5   
   -   5        $ 
ListAllBtn��5      $
��LIST��6%   $
��Left=�64   $��415,124,0,0q�6O   $	��Top=�6d   $��97��6|   $
��Bold"�6�   6�   �� 5   
   -   5        $ 	UpdateBtn��5      $��UPDATE��6$   $
��Left=�65   $��415,166,0,0q�6P   $	��Top=�6e   $��97��6}   $
��Bold"�6�   6�   �� 5   
   -	   5        $ 	DeleteBtn��5      $��DELETE��6$   $
��Left=�65   $��415,201,0,0q�6P   $	��Top=�6e   $��97��6}   $
��Bold"�6�   6�   �� 5   
   -
   5        $ 	SearchBtn��5      $��SEARCH��6$   $
��Left=�65   $��292,130,0,0q�6P   $	��Top=�6e   $��96��6}   $
��Bold"�6�   6�   �� 5   
   -   5         ��Name$ 
Responselb��5      $��Label��6$   $
��Left=�64   $��40��6O   $��
546,94,0,0q�6[   $	��Top=�6o   $	��200��6�   ���	#FFF80707$y�Hidden=�6�   �� 5   
   -   5        $ SaleBtn��5      $
��SALE��6"   $
��Left=�61   $��26��6L   $��	53,47,0,0q�6X   $	��Top=�6k   $��82��6�   ���	#FFFB0707���	#FF030B006�   5      5      