   M S B A M L   `   `   `  ����E  AIntepreter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Intepreter.ViewIntepreter.View  5   	   9!clr-namespace:Intepreter.BehaviorIntepreter.Behavior  5	   	   ;"clr-namespace:Intepreter.ViewModelIntepreter.ViewModel  5
   	   i9clr-namespace:Intepreter.Controls.GraphicOperationBuilder+Intepreter.Controls.GraphicOperationBuilder  5   	   g8clr-namespace:Intepreter.Controls.GraphicOperationEditor*Intepreter.Controls.GraphicOperationEditor  5   	   a5clr-namespace:Intepreter.Controls.TextOperationEditor'Intepreter.Controls.TextOperationEditor  5   	   $    Intepreter.View.MainWindowView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=16.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   W SDevExpress.Mvvm, Version=16.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30Adxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm   5   	   +localclr-namespace:Intepreter.View   5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   )b!clr-namespace:Intepreter.Behavior  5	   	   2	viewModel"clr-namespace:Intepreter.ViewModel  5
   	   WgraphicOperationBuilder9clr-namespace:Intepreter.Controls.GraphicOperationBuilder  5   	   UgraphicOperationEditor8clr-namespace:Intepreter.Controls.GraphicOperationEditor  5   	   OtextOperationEditor5clr-namespace:Intepreter.Controls.TextOperationEditor  5   	     � Title$  
Intepreter��5   	   $	��350��6   $	��525��6)    � WindowState$ 	Maximized=�65    � DataContext 5      (   "Intepreter.ViewModel.MainViewModel  5   
    � 	Resources 5       �� DataTypeR   LIntepreter.Controls.GraphicOperationBuilder.GraphicOperationBuilderViewModel6   0Intepreter.Controls.GraphicOperationBuilder.ViewJ   DIntepreter.Controls.TextOperationEditor.TextOperationEditorViewModelE   ?Intepreter.Controls.TextOperationEditor.TextOperationEditorViewP   JIntepreter.Controls.GraphicOperationEditor.GraphicOperationEditorViewModelK   EIntepreter.Controls.GraphicOperationEditor.GraphicOperationEditorView �� 
TargetType �� Property �� Value �� Triggers	 P� Property
 P� Value��%1  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)'�� �     �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5       �� 5"   
   " ��6   .�5#      ��  �@��TextWrapping$
 Wrap=�6-   �� 5$       �@��AcceptsReturn . 6.    5%      P� 5&      	 �@J�	IsFocused
 . . �5'      ��  � ��
 �����6;   5(      P� 5)      	 �@J�	IsFocused
 .  . �5*      ��  � ��
 �����6;   5+      5-      5.      .��51      �  � ColumnDefinitions 52   
   �� 53      �� 54      $
��Auto �6   �� 55       � RowDefinitions 57   
   �� 58      $
��Auto �6   �� 59      �� 5:      $
��Auto �6   �� 5;      .+�5?   
   o� $��3��6   $��0��6#   .@�5@      m� $��Файл��6   .@�5A      m� $��Загрузить��6    m� Command 6.   �� *LoadAllFromBinaryFileCommand+m� 5B      $��Сохранить��6    6.   �� *SaveAllToBinaryFileCommand+5C      m� 5D      $��Выполнить��6    6*   �� *PerformCommand+m� 5E      $!��Очистить вывод��6    6/   �� *ClearOutputCommand+5F      �� 5J   
   $��1��6   $��1��6$   $��3��64   $��5��5K      $��Center=�5L      $��Stretch=�5M      �� 5O   
   $��2��6   $��0��6$   $��3��64   $��5��5P      $��Center=�5Q      $��Stretch=�5R      �� 5V   
   $��0��6   $��1��6)   ��5W      �� *
TextEditor+�� 5[   
   $��2��6   $��1��6'   $
��Auto=�5\      $
��Auto=�5]      .��5^      �� ��6   �� *GraphicEditor+5`      �� 5d   
   $��0��6   $��3��6'   $
��Auto=�5e      $
��Auto=�5f      .��5g      ��  �� 
IsReadOnly . ��6   �� *Output.Text+5h      5i      �� 5m   
   $��2��6   $��3��6'   $
��Auto=�5n      .��5o      �� ��6   �� *GraphicBuilder+5p      5q      5r      