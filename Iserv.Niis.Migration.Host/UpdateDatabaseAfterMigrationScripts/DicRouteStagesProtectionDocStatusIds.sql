update DicRouteStages set ProtectionDocStatusId = (select id from DicProtectionDocStatuses where code = 'A') where code = 'B05'
update DicRouteStages set ProtectionDocStatusId = (select id from DicProtectionDocStatuses where code = 'A') where code = 'TM05'
update DicRouteStages set ProtectionDocStatusId = (select id from DicProtectionDocStatuses where code = 'A') where code = 'SA05'
update DicRouteStages set ProtectionDocStatusId = (select id from DicProtectionDocStatuses where code = 'A') where code = 'PO05'
update DicRouteStages set ProtectionDocStatusId = (select id from DicProtectionDocStatuses where code = 'A') where code = 'U05'
update DicRouteStages set ProtectionDocStatusId = (select id from DicProtectionDocStatuses where code = 'A') where code = 'TMI05'
update DicRouteStages set ProtectionDocStatusId = (select id from DicProtectionDocStatuses where code = 'A') where code = 'B02.2.1.0'
update DicRouteStages set ProtectionDocStatusId = (select id from DicProtectionDocStatuses where code = 'A') where code = 'SA02.2.2'
update DicRouteStages set ProtectionDocStatusId = (select id from DicProtectionDocStatuses where code = 'A') where code = 'U02.2.3' and nameru = '������� ��� �������� � �����'