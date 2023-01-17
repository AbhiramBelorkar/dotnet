namespace DAL.Connected;
using BOL;
using MySql.Data.MySqlClient;
public class DBManager{

    public static string conString=@"server=localhost;port=3306;user=root; password=root123;database=player";
   
    public static List<Player> getAllPlayersDb(){
        List<Player> allPlayers = new List<Player>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;

        try{
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            string query = "SELECT * FROM players";
            cmd.CommandText = query;
            MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read()){
                int id = int.Parse(reader["id"].ToString());
                string name = reader["name"].ToString();
                string city = reader["city"].ToString();
                int matches = int.Parse(reader["matches"].ToString());

                Player player = new Player {
                    Id = id,
                    Name = name,
                    City = city,
                    Matches = matches
                };

                allPlayers.Add(player);
            }

        } catch (Exception e){
            Console.WriteLine(e.Message);
        } finally {
            con.Close();
        }

        return allPlayers;
    }

    public static Player getPlayerByIdDb(int id){
        Player player = null;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;

        try{
            con.Open();
            string query = "SELECT * FROM player WHERE id= "+id;
            MySqlCommand cmd = new MySqlCommand(query,con);
            MySqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("In dal Db manager by id");
            if(reader.Read()){
                int plyid = int.Parse(reader["id"].ToString());
                string name = reader["name"].ToString();
                string city = reader["city"].ToString();
                int matches = int.Parse(reader["matches"].ToString());

                player = new Player{
                    Id = plyid,
                    Name = name,
                    City = city,
                    Matches = matches
                };
            }

        } catch(Exception e){
            Console.WriteLine(e.Message);
        } finally {
            con.Close();
        }

        return player;
    }

    public static bool Insert(Player thePlayer){
        bool status=false;
        string query = "INSERT INTO players(id,name,city,matches)" +
                            "VALUES('" + thePlayer.Id + "','" + thePlayer.Name + "','" + thePlayer.City + "','" + thePlayer.Matches + "')";

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try{
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();  //DML
            status = true;
            Console.WriteLine("Inside dal insert method "+status);
        } 
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }               
        return status;
     }

    
    public static bool Update(Player thePlayer)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            Console.WriteLine("In update method dal");
            string query = "UPDATE players SET city='" + thePlayer.City + "', name='" + thePlayer.Name + "' , matches='" + thePlayer.Matches + "' WHERE id=" + thePlayer.Id;
            MySqlCommand command = new MySqlCommand(query, con);
            con.Open();
            command.ExecuteNonQuery();
            status = true;
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return status;
    }

    public static bool Delete(int id){
        bool status=false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "DELETE FROM players WHERE id=" + id;
            MySqlCommand command = new MySqlCommand(query, con);
            con.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
      return status;
    }
}