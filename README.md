# LogicLoop
==> For chessboard task ,C# code genrated chessboard html file is in the Root ChessBoard folder.                                      

==> **For assignment 2 need to change connection string  **                                                                                                           
==> database mdf file is in root database folder

==> Basic Authentication is made with static username and password i can do it also with db query if needed so you just enter **username = admin, password  = admin**.
==> APi url is http://localhost:56861/                                                                                    
==> for getting all tast you need to call **Get** method http://localhost:56861/todo/api/v1.0/tasks                                                   
==> if you want specific task then call **Get** method http://localhost:56861/todo/api/v1.0/tasks with json parameter "id":integer value
==> if you want to insert data then call **Post** http://localhost:56861/todo/api/v1.0/tasks with json parameter "title":"title","description":"description"
==> if you want to update the data then call **Post** method http://localhost:56861/todo/api/v1.0/tasks with json parameter "id":integer value,"title":"title","description":"description"
==> if you want to Delete the data then call **Delete** method http://localhost:56861/todo/api/v1.0/tasks with json parameter "id":integer value
