classDiagram
direction BT
class table_accounts {
   varchar(75) login
   varchar(20) password
   tinyint(1) is_delete
   int role_id
   int account_id
}
class table_roles {
   varchar(50) name
   int role_id
}
class table_users {
   varchar(125) first_name
   varchar(255) last_name
   varchar(125) email
   varchar(20) tel
   int user_id
}

table_accounts  -->  table_roles : role_id
table_users  -->  table_accounts : user_id:account_id
