   M S B A M L   `   `   `  ���� J  FSimpleInstaller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SimpleInstallerSimpleInstaller       SimpleInstaller.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:SimpleInstaller     -   $��Window��  � Title$  Quick Installer��$	��400��$	��700�� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=����	#FF000534.��� ����  �� ImageSource$% pack://application:,,,/back.png�� j� Stretch$
 Fill=� � RowDefinitions �� $��20 ��� $��* �.+�� -   $��0�����	#BF000000.+��� -   $��Right=� � Cursor$
 Hand��$��20�� �� Padding$ 0q�$��20��
�������$��15(�$��Center=�
������ 	 �� TextAlignment$	 Center=�X�� -   $��	startpage��$��1��$y�Visible=�.+��� -   
 ��Name$

 Logo��$��	0,20,0,10q�$%��pack://application:,,,/Logo.png��$	��600��$��75���� -    ��Name$
 Name��$
��auto��
�������$��Center=�$��36(�$��sdfsdf���� -   $ 	Developer��$��30��$��	0,00,0,10q�$
��auto�����	#FFE6E6E6$��Center=�$��24(�$��
sdfsdafsdf���� -   $
 Hand��$	��200��$ 7q�$��65��
�������$��Center=�$��36(����	#FF811700$��Center=�$	 Center=�	Install�� -	   $
 Hand��$	��200��$��25��
�������$��Center=�$��18(����	#FF818181$��Center=�$	 Center=�
Settings�� -
   $
 Hand��$��0,30,0,5q�$
��auto��
�������$��Center=�$��18(�Installer by:�� -   $
 Hand��$$��pack://application:,,,/log.png��$	��100���� -    ��Name$ settings��$	��400��$��75�����	#E5000000$��1��$y�	Collapsed=�.+�� ���	#BF000000.+��� -   $��Right=�$
 Hand��$��20��$ 0q�$��20��
�������$��15(�$��Center=�
������ $	 Center=�X� $
��Left=�.+��� $��30,0,0,0q�$
��Left=�
�������Download Location:�� -   $��Location��$	��200��$��	150,0,0,0q����	#FF202020���	#FF656565
�������� $��	0,10,0,10q�$
��Left=�.+��� $��30,0,0,0q�$
��Left=�
�������Add desktop shortcut:�� -   $��Shortcut��$��	150,0,0,0q� d� 	IsChecked$
 TrueY��� -   $��downloadpage��$��1��$y�	Collapsed=�.+��� -   $ InstallingTitle��$��	00,80,0,0q�$
��auto��
�������$��Center=�$��36(�$��
Installing��� $	��200��$��40��$��	00,50,0,0q�
�������.+�� -    �Name$ progressBar��$
��Left=�$��0��$��40��
���  ���� -   $��endpage��$��1��$y�	Collapsed=�.+��� -   $��logoo��$��	0,20,0,10q�$%��pack://application:,,,/Logo.png��$	��600��$��75���� $ 0,0,0,30q�$
��auto��
�������$��Center=�$��36(�$��Install Completed���� -   $
 Hand��$	��200��$ 7q�$��65��
�������$��Center=�$��36(����	#FF811700$��Center=�$	 Center=�Launch�� -   $
 Hand��$	��200��$��25��
�������$��Center=�$��18(����	#FF818181$��Center=�$	 Center=�Close Installer�� -   $
 Hand��$��0,30,0,5q�$
��auto��
�������$��Center=�$��18(�Installer by:�� -   $
 Hand��$$��pack://application:,,,/log.png��$	��100��