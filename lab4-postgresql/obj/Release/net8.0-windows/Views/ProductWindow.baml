   M S B A M L   `   `   `  ���� J  Flab4-postgresql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:lab4_postgresql.Viewslab4_postgresql.Views  G(clr-namespace:lab4_postgresql.ViewModelslab4_postgresql.ViewModels  )    #lab4_postgresql.Views.ProductWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:lab4_postgresql.Views     >	viewmodel(clr-namespace:lab4_postgresql.ViewModels       � Title$  ProductWindow��$	��200��$	��300��.��� $��10q� � 	Resources  �� 
TargetType �� Property �� Value��%^   '��       �� " ��.���  � ��$ 70����  � ��$ 25����  � ��$ 5,0,0,0q� � ColumnDefinitions �� $
��Auto ���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��.��Название:�� $��1��$��0������ *ProductName+ �� UpdateSourceTrigger$ PropertyChanged=��� $��0��$��1��.��	Цена:�� $��1��$��1������ *Price+$ PropertyChanged=��� $��0��$��2��.��Количество:�� $��1��$��2������ *
Quantity+$ PropertyChanged=��� $��0��$��3��.�� Номер категории:�� $��1��$��3������ *
CategoryId+$ PropertyChanged=��� $��0��$��2��$��4�� �� Orientation$ 
Horizontal=�$��Right=�$��10 10q�.+��� -   $��okButton��	 �� 	IsDefault$
	 True��.��Добавить�� -   $��cancelButton��
 �� IsCancel$

 True��.��Отмена