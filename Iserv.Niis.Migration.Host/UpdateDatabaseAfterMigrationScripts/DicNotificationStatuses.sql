INSERT [dbo].[DicNotificationStatuses] ([DateCreate], [DateUpdate], [Code],  [NameRu], [NameEn], [NameKz], [Description]) VALUES 
(getdate(),getdate(),N'PNF',N'Мобильный телефон не найден', null, null, null),
(getdate(),getdate(),N'SS',N'SMS отправлено.', null, null, null),
(getdate(),getdate(),N'SSF',N'При отправке SMS на сервере произошла ошибка. Обратитесь к своему системному администратору.', null, null, null),
(getdate(),getdate(),N'ENF',N'Email не найден', null, null, null),
(getdate(),getdate(),N'ES',N'Email отправлен', null, null, null),
(getdate(),getdate(),N'ESF',N'При отправке Email на сервере произошла ошибка. Обратитесь к своему системному администратору.', null, null, null),
(getdate(),getdate(),N'ECNF',N'Нет Адресата для переписки', null, null, null),
(getdate(),getdate(),N'SCNF',N'Нет Адресата для переписки', null, null, null)