   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  F BDoorStorage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DoorStorageDoorStorage    DoorStorage.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     +localclr-namespace:DoorStorage       � Title$  DoorStorage��$	��800��$
��1000�� � 	Resources  �� 
TargetType �� Property �� Value��%�   '��       �� " ��.���  � ��$ Times New Roman)���  � ��$ 14(���  � ��$
 Bold"���  � ��$ 5q���  � ��$ 5q�.��� .+��� -   $��tabControl1��.@��� $��
Поиск�� �� 
IsSelected . .���  � RowDefinitions �� �� $��50 �.+�&   System.Windows.Controls.DataGrid  -     Name$ dataGridTable0��   AutoGenerateColumns .  $
��Auto=�$
��Auto=����� *Orders+.   (System.Windows.Interactivity.Interaction	   Triggers	 /   )System.Windows.Interactivity.EventTrigger  
   	EventName$
 MouseRightButtonDown��.   (System.Windows.Interactivity.TriggerBase   Actions. 6   0System.Windows.Interactivity.InvokeCommandAction     Command �� *EditCommand+   CommandParameter ��  �� ElementName$ dataGridTable0�� �� Path$ SelectedItem�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *Id+  $ 
номер��$ 50  �� *Number+  $% дата поступления��$	 150  �� *DateofReceipt+  $ 
адрес��$	 150  �� *CustomerAddress+  $ телефон��$	 150  �� *CustomerPhone+�� $��1�� �� Orientation$ 
Horizontal=�$
��Left=�.+��� $��Добавить��$��10q����� *
AddCommand+�� $��Изменить��$��10q����� *EditCommand+���� $ dataGridTable0��$ SelectedItem��� $��Удалить��$��10q����� *DeleteCommand+���� $ dataGridTable0��$ SelectedItem��� -   $��TextBox1��$��10q�$	��300��
��� � �.��	   $
 TextChanged��.    �� *TextChangedCommand+.���� $��
Итого��$��10q����� *Sum+���� $ dataGridTable0��$ SelectedItem��� $��10q�$��
Сумма��$��Center=��� -   $
��Sum0��$��10q�$	��100��
���  ���� $��10q�$��%��$��Center=��� -   $��Percent0��$��10q�$��80��
���  ���� $��Прибывшие�� .  .���  �� �� $��50 �.+�  -   $ dataGridTable1�� .  $
��Auto=�$
��Auto=����� *	Orders1+	   $
 MouseRightButtonDown��.    �� *EditCommand+ �� $ dataGridTable1��$ SelectedItem�   $ Id��$ 50  �� *Id+  $ 
номер��$ 50  �� *Number+  $% дата поступления��$	 150  �� *DateofReceipt+  $ 
адрес��$	 150  �� *CustomerAddress+  $ телефон��$	 150  �� *CustomerPhone+�� $��1��$ 
Horizontal=�$
��Left=�.+��� $��Добавить��$��10q����� *
AddCommand+�� $��Изменить��$��10q����� *EditCommand+���� $ dataGridTable1��$ SelectedItem��� $��Удалить��$��10q����� *DeleteCommand+���� $ dataGridTable1��$ SelectedItem�� $	��300���� $��
Итого��$��10q����� *Sum+���� $ dataGridTable1��$ SelectedItem��� $��10q�$��
Сумма��$��Center=��� -   $	��Sum��$��10q�$	��100��
���  ���� $��10q�$��%��$��Center=��� -   $��Percent��$��10q�$��80��
���  ���� $��Сделанные�� .  .���  �� �� $��50 �.+�  -	   $ dataGridTable2�� .  $
��Auto=�$
��Auto=����� *	Orders2+	   $
 MouseRightButtonDown��.    �� *EditCommand+ �� $ dataGridTable2��$ SelectedItem�   $ Id��$ 50  �� *Id+  $ 
номер��$ 50  �� *Number+  $% дата поступления��$	 150  �� *DateofReceipt+  $ 
адрес��$	 150  �� *CustomerAddress+  $ телефон��$	 150  �� *CustomerPhone+�� $��1��$ 
Horizontal=�$
��Left=�.+��� $��Добавить��$��10q����� *
AddCommand+�� $��Изменить��$��10q����� *EditCommand+���� $ dataGridTable2��$ SelectedItem��� $��Удалить��$��10q����� *DeleteCommand+���� $ dataGridTable2��$ SelectedItem�� $	��300���� $��
Итого��$��10q����� *Sum+���� $ dataGridTable2��$ SelectedItem��� $��10q�$��
Сумма��$��Center=��� -
   $
��Sum2��$��10q�$	��100��
���  ���� $��10q�$��%��$��Center=��� -   $��Percent2��$��10q�$��80��
���  ���� $��Отправленные�� .  .���  �� �� $��50 �.+�  -   $ dataGridTable3�� .  $
��Auto=�$
��Auto=����� *	Orders3+	   $
 MouseRightButtonDown��.    �� *EditCommand+ �� $ dataGridTable3��$ SelectedItem�   $ Id��$ 50  �� *Id+  $ 
номер��$ 50  �� *Number+  $% дата поступления��$	 150  �� *DateofReceipt+  $ 
адрес��$	 150  �� *CustomerAddress+  $ телефон��$	 150  �� *CustomerPhone+�� $��1��$ 
Horizontal=�$
��Left=�.+��� $��Добавить��$��10q����� *
AddCommand+�� $��Изменить��$��10q����� *EditCommand+���� $ dataGridTable3��$ SelectedItem��� $��Удалить��$��10q����� *DeleteCommand+���� $ dataGridTable3��$ SelectedItem��� $��Удалить все��$��10q����� *DeleteAllCommand+� $	��200���� $��
Итого��$��10q����� *Sum+���� $ dataGridTable3��$ SelectedItem��� $��10q�$��
Сумма��$��Center=��� -   $
��Sum3��$��10q�$	��100��
���  ���� $��10q�$��%��$��Center=��� -   $��Percent3��$��10q�$��80��
���  ��