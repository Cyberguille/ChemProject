   M S B A M L   `   `   `  ����a  ]PresentationFramework.Aero, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  5      H DSearchTextBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:UIControls
UIControls 5      \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35   SearchTextBox_Background  �� Color  SearchTextBox_Foreground  SearchTextBox_Border �� 
StartPoint �� EndPoint � Color � Offset ! SearchTextBox_BorderMouseOver " SearchTextBox_SearchIconBorder & "SearchTextBox_SearchIconBackground , (SearchTextBox_SearchIconBorder_MouseOver 0 ,SearchTextBox_SearchIconBackground_MouseOver , (SearchTextBox_SearchIconBorder_MouseDown 0	 ,SearchTextBox_SearchIconBackground_MouseDown  
 SearchTextBox_LabelTextColor   UIControls.SearchTextBox �� 
TargetType �� Property �� Value �� 
TargetType	 ��Name
 �Name � ColumnDefinitions ��Name ��Name �� RelativeSource �� Path ��Name � ToolTip �� Triggers P� 
SourceName P� Property P� Value �� 
TargetName ]� 
Conditions �� Property �� Value�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5      RmwtJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero  5      lclr-namespace:UIControls  5      %o  &	        &	      &	 >     &	     &	 �    &	 �    &	     &	 �    &	 �    &		 E    &	
 B    '   `    7   7  7  7 
 7  7  7  7  �� 5      $  White��65   �� 5      $  Black��65   �� 5	      $	 0,0&�65   $	 0,1&�6F   .��5
      � $ 	#FFABADB3��6   $
 0.05Q�6%   � 5      $ 	#FFE2E3EA��6   $
 0.07Q�6%   � 5      $ 	#FFE4E9EF��6   $ 1Q�6%   5      �� 5      $	 0,0&�6>   $	 0,1&�6O   .��5      � $ 	#FF5C97C1��6   $
 0.05Q�6%   � 5      $ 	#FFB9D7EB��6   $
 0.07Q�6%   � 5      $ 	#FFC7E2F1��6   $ 1Q�6%   5      �� 5      $  White��6;   �� 5      $  White��6?   �� 5      $	 0,0&�6I   $	 0,1&�6Z   .��5      � $ 	#FFFFFFFF��6   $ 0Q�6%   � 5      $ 	#FFE5F4FC��6   $ 1Q�6%   5      �� 5      $	 0,0&�6M   $	 0,1&�6^   .��5      � $ 	#FFE7F5FD��6   $ 0Q�6%   � 5      $ 	#FFD2EDFC��6   $	 0.5Q�6%   � 5      $ 	#FFB6E3FD��6   $
 0.51Q�6%   � 5      $ 	#FF9DD5F3��6   $ 1Q�6%   5      �� 5      $	 0,0&�6I   $	 0,1&�6Z   .��5       � $ 	#FFFFFFFF��6   $ 0Q�6%   � 5!      $ 	#FFE5F4FC��6   $ 1Q�6%   5"      �� 5#      $	 0,0&�6M   $	 0,1&�6^   .��5$      � $ 	#FFE7F5FD��6   $ 0Q�6%   � 5%      $ 	#FFD2EDFC��6   $	 0.5Q�6%   � 5&      $ 	#FFB6E3FD��6   $
 0.51Q�6%   � 5'      $ 	#FF9DD5F3��6   $ 1Q�6%   5(      �� 5)      $
  Gray��69   �� 5+      "   6+   .�5,      ��  � ��8   6#   �� 5-       � ��8  6$   �� 5.       � ��8  6#   �� 5/       � ��$ 1q�6(   �� 50       �@J�SnapsToDevicePixels . 6,   �� 51       �@  	LabelText$ Search��6"   �� 52       �@�FocusVisualStyle 6)   Z� �� 53       �@  LabelTextColor8  6'   �� 54       � �� 55      �� 56   
   "   6   .R�57      �� $	 Border��6   #��z��58      #��z��59      #��z��5:      ._�5;      � $
 
LayoutGrid��6    5<      �� 5=      $��* �6+   �� 5>      $
��Auto �6+   �� 5?      $
��Auto �6+   �� 5@      $
��Auto �6+   .+�5B      �� $ PART_ContentHost��6,   $��2q�6!   $��0��6F   $��Center=�6V   �� 5C      $ 	LabelText��6   $��2q�5D      $��0��5E      $��2,0,0,0q�5J      $��Center=�5K      $��Italic$�5L      ��5F      ��  �� *TemplatedParent+$ LabelTextColor���5H      ��  �� *TemplatedParent+$ 	LabelText�5L      �� 5M      $	 PART_SearchIconBorder��6   $��2��5N      $��Stretch=�5O      $��Stretch=�5P      8�� ._�5S      �� $ 
SearchIcon��6    $
��None=�5T       $��15��5U       $��15��5V       $��Center=�5W       $��Center=�5X       $F��@pack://application:,,,/SearchTextBox;component/Images/search.png��5Y       $ Click to search��6j   5Z      �� 5\      $	 PART_SpecifySearchType��6   $��1��5]      $��Stretch=�5^      $��Stretch=�5_      8�� ._�5b      �� $ SpecifySearchType��6    $
��None=�5c       $��15��5d       $��15��5e       $��Center=�5f       $��Center=�5g       $G��Apack://application:,,,/SearchTextBox;component/Images/Key-Add.png��5h       $ Choose section(s)��6k   5k      �� 5m      $	 PART_PreviousItem��6   $��3��5n      $��Stretch=�5o      $��Stretch=�5p      8�� ._�5r      �� $ PreviousIcon��6$   $
��None=�5s      $��15��5t      $��15��5u      $��Center=�5v      $��Center=�5w      $H��Bpack://application:,,,/SearchTextBox;component/Images/Previous.png��5x      $ Previous keyword(s)��6h   5z      5{      5|       5}      P� 5~      $ 	LabelText��6:    �@J�IsMouseOver . . �5      �� $ 
LayoutGrid��6/    � �� �#F3F9F26G   �� 5�       �@�Cursor$ IBeam��6+   5�      P� 5�       �@J�IsMouseOver .  . �5�      �� $ 
LayoutGrid��6/    � �� �#DCEED96G   5�      P� 5�       �@J�IsKeyboardFocusWithin . . �5�      �� 8   � ��60   5�      P� 5�       �@  HasText . . �5�      �� $ 	LabelText��6/    � y�$ Hidden=�6F   5�      ]� 5�       5�      �� 5�       �@  HasText . 6/   ./�5�      �� $ 
SearchIcon��5�       � ��$E ?pack://application:,,,/SearchTextBox;component/Images/clear.png��5�      5�      5�      5�      5�      5�      