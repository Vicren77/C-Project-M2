   M S B A M L   `   `   `  ����M  IWpf_Projet_Trading, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Wpf_Projet_TradingWpf_Projet_Trading  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   R   e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089�_clr-namespace:System.Windows.Controls.Ribbon.Primitives;assembly=System.Windows.Controls.Ribbon)System.Windows.Controls.Ribbon.Primitives 6�   #    Wpf_Projet_Trading.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Wpf_Projet_Trading     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   >Wpf4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  6R   p
Primitives_clr-namespace:System.Windows.Controls.Ribbon.Primitives;assembly=System.Windows.Controls.Ribbon  6�     � Title$  
MainWindow��5	   	   $	��533��6   $	��797��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $
��137* �6   �� 5      $	��88* �6   �� 5      $
��292* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ Inverted=�6#   $��16q�5      .��5      ]� .+�5      '  !MaterialDesignThemes.Wpf.PopupBox  $��Right=�5         PlacementMode$ BottomAndAlignRightEdges=�5         PopupContent. 5      �� .@�5      �� $��Hello World��6&   �� 5      $��
Nice Popup��6&   �� 5      $��Goodbye.��6&   5      5      �� 5       �� Orientation$ 
Horizontal=�5      .+�5      d�  '  #MaterialDesignHamburgerToggleButton#���   5    	   �� 5!      $��Center=�5"   	   $��16 0 0 0q�5#   	   $��Trading application��6   5$      5%      5&      #  MaterialDesignThemes.Wpf.Card  5(   
   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=�5)      $��32q�5*      $��	24,98,0,0q�6   $��3��6%   $
��Left=�66   $	��402��6Q   $	��290��6]   $	��Top=�6j   .��5+      #  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$
 Left=�6E   $��-24,-14,-17,-24q�6[      Series 6!   �� *SeriesCollection+	   AxisY	 5-        LiveCharts.Wpf.Axis  
   Title$
 Prices��6      LabelFormatter 6.   �� *
yFormatter+   AxisX 50        $

 Time��6      Labels 6,   �� *Labels+52      54      �� 55   
   $��	434,0,0,0q�69   $��2��6L   $
��Left=�6Y   $	��353��6t   $	��236��6�   $	��Top=�6�   ��6   �� *crypto_Prices+ �� View 56      �� 57      .P�58      �� $��Crypto 1��6N    �� Width$	 100��6`    �� DisplayMemberBinding 6%   �� *	weight1+6n   �� 59      $��Crypto 2��6N   $	 100��6`    6%   �� *	weight2+6n   �� 5:      $��Crypto 3��6N   $	 100��6`    6%   �� *	weight3+6n   �� 5;      $
��Risk��6K   $	 100��6Y    6%   �� *Risk+6g   �� 5<      $	�� ER��6K   $	 100��6X    6%   �� *ExpR+6f   5=      5?      �� 5@   
   -   5         ��Name$ Crypto1��5@      $
��Left=�6#   $��	457,0,0,0q�6>   $��1��6Q   $��Crypto1��6^    �� TextWrapping$
 Wrap=�6m   $	��Top=�6�   $	��120��6�   �� 5A   
   -   5        $ Crypto2��5A      $��	624,0,0,0q�6#   $��1��66   $��Crypto2��6C   $
 Wrap=�6R   $	��Top=�6f   $
��Left=�6~   $	��120��6�   �� 5B   
   -   5        $ Crypto3��5B      $
��Left=�6#   $��
457,44,0,0q�6>   $��1��6R   $��Crypto3��6_   $
 Wrap=�6n   $	��Top=�6�   $	��120��6�   �� 5D   
   -   5          MaterialDesignRaisedButton#��[ 5E       � ToolTip$/ )Resource name: MaterialDesignRaisedButton��5F      $��
610,47,0,0q�69   $��1��6M   $
��Left=�6Z   $	��167��6u   $��32��6�   $	��Top=�6�   .��6�   	Portfolio5H      5J      5K      