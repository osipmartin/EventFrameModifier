   M S B A M L   `   `   `  ����M  IEventFrameModifier, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:EventFrameModifierEventFrameModifier  5   	   #    EventFrameModifier.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:EventFrameModifier     5   	     � Title$  
MainWindow��5   	   $	��380��6   $	��535��6)   .��5	      � $��0,0,0,0q�6   .+�5
   
   �� -   5         ��Name$	 EFT��5
      $��Center=�6    $��0,92,0,0q�6=   $	��Top=�6O   $	��128��6g   6s   �� 5   
   -   5        $ 
AFDatabase��5      $��Center=�6'   $��-325,92,0,0q�6D   $	��Top=�6Y   $	��128��6q   $��1��6�   �� 5   
   -   5        $ MatchingAttribute��5      $��Center=�6.   $��
325,92,0,0q�6K   $	��Top=�6_   $	��128��6w   6�   �� 5   
   $��Database��6   $��Center=�6#   $��-325,66,0,0q�6@   $	��Top=�6U   $	��128��6m   $��Center=�6y   �� 5   
   $��Event Frame Template��6   $��Center=�6/   $��0,66,0,0q�6L   $	��Top=�6^   $��Center=�6v   �� 5   
   $��Matching Attribute��6   $��Center=�6-   $��
325,66,0,0q�6J   $	��Top=�6^   $	��128��6v   $��Center=�6�   �� 5   
   $��CSV File��6   $��Center=�6#   $��32,223,32,0q�6@   $	��Top=�6U    J� RenderTransformOrigin$ 0.148,-0.34&�6m   $	��454��6�   $��Center=�6�   �� 5   
   -   5        $��Update��5      $��Center=�6"   $��43��6?   $��	0,297,0,0q�6K   $	��Top=�6^   $	��128��6v   6�   �� 5   
   -   5        $ AFServer��5      $��Center=�6%   $��0,32,0,0q�6B   $	��Top=�6T   $	��128��6l   $ 0.5,0.5&�6�   �� 5   
   $��Server��6   $��Center=�6!   $��0,10,0,0q�6>   $	��Top=�6P   $	��128��6h   $��Center=�6t   �� 5   
   -   5         ��Name$	 CSV��5      $��Center=�6   $��23��6<   $��32,249,68,0q�6H    �� TextWrapping$ NoWrap=�6]    �� AcceptsReturn .  $	��Top=�6�   $	��418��6�   �� 5   
   -   5         ��Name$ LogFileButton��5      $��Center=�6(   $��462,249,32,0q�6E   $	��Top=�6[   $��24��6s   $ -0.534,-0.73&�6~   $��23��6�   .��5      �� $��Center=�6   .+�5      �� -   5         ��Name$ lfbutton��5      $��Folder_32x.png��6*   $��Center=�6B   5      5      �� 5   
   -	   5         ��Name$ label1_Copy��5      $��
Start Date��6%   $��Center=�6:   $��-162,143,0,0q�6W   $	��Top=�6m   $	��120��6�   $��11(�6�   $��25��6�   $��Center=�6�   �� 5   
   -
   5        $ label1_Copy1��5      $��End Date��6&   $��Center=�69   $��162,143,0,0q�6V   $	��Top=�6k   $	��120��6�   $��11(�6�   $��25��6�   $��Center=�6�   �� 5   
   -   5        $ 	StartDate��5      $��Center=�6%   $��23��6B   $��-162,168,0,0q�6N   $
 Wrap=�6d   $	��Top=�6x   $	��120��6�   $��1��6�   �� 5   
   -   5        $ EndDate��5      $��Center=�6#   $��24��6@   $��162,168,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��120��6�   $��1��6�   5      5      