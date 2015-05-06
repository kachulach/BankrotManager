using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MacedonianRedCrossYouth
{
    public class DatabaseManagement
    {
        
        private static SqlConnection getConnection()
        {
            //konekcija za do bazata
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            return konekcija;
        }
/*
        public static List<Organization> getUserOrganizations(int user_id)
        {
            List<Organization> organizations = new List<Organization>();
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT DISTINCT o.* FROM Organizations o, URO uro WHERE uro.user_id=@user_id and o.organization_id=uro.organization_id";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@user_id", user_id);
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {

                    Organization o = new Organization(int.Parse(citac[0].ToString()), citac[1].ToString());
                    organizations.Add(o);

                }
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }

            return organizations;
        }

        public static List<ActivityType> getActivityTypes()
        {
            List<ActivityType> activity_types = new List<ActivityType>();
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT * FROM ActivityTypes";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {

                    ActivityType at = new ActivityType(int.Parse(citac[0].ToString()), citac[1].ToString());
                    activity_types.Add(at);

                }
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());

            }
            finally
            {
                konekcija.Close();
            }

            return activity_types;
        }

        public static List<Organization> getOrganizations()
        {
            List<Organization> organizations = new List<Organization>();
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT * FROM Organizations";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {

                    Organization o = new Organization(int.Parse(citac[0].ToString()), citac[1].ToString());
                    organizations.Add(o);

                }
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }

            return organizations;
        }

        public static List<Nationality> getNationalities()
        {
            List<Nationality> nationalities = new List<Nationality>();
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT * FROM Nationalities";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {

                    Nationality o = new Nationality(int.Parse(citac[0].ToString()), citac[1].ToString());
                    nationalities.Add(o);

                }
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());

            }
            finally
            {
                konekcija.Close();
            }

            return nationalities;
        }

        public static List<Faculty> getFaculties()
        {
            List<Faculty> faculties = new List<Faculty>();
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT * FROM Faculties";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {

                    Faculty f = new Faculty(int.Parse(citac[0].ToString()), citac[1].ToString());
                    faculties.Add(f);

                }
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());

            }
            finally
            {
                konekcija.Close();
            }

            return faculties;
        }

        public static User authenticateUser(string username, string password)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT * FROM Users WHERE username=@username AND password=@password AND is_active = 1";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@username", username);
            komanda.Parameters.AddWithValue("@password", password);

            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                if (citac.Read())
                {

                    User u = new User();
                    u.user_id = int.Parse(citac["user_id"].ToString());
                    u.first_name = citac["first_name"].ToString();
                    u.last_name = citac["last_name"].ToString();
                    u.organization_id = int.Parse(citac["organization_id"].ToString());

                    return u;
                }
                else
                    return null;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return null;
        }

        public static User getUserByID(int id)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT u.*, o.organization_name FROM Users u, Organizations o WHERE u.user_id=@user_id AND u.organization_id=o.organization_id";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@user_id", id);

            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                if (citac.Read())
                {

                    User u = new User();
                    u.user_id = int.Parse(citac["user_id"].ToString());
                    u.first_name = citac["first_name"].ToString();
                    u.last_name = citac["last_name"].ToString();
                    u.username = citac["username"].ToString();
                    u.gender = Convert.ToBoolean(citac["gender"].ToString());
                    u.birth_date = Convert.ToDateTime(citac["birth_date"].ToString());
                    u.organization_id = int.Parse(citac["organization_id"].ToString());
                    u.organization_name = citac["organization_name"].ToString();
                    u.join_date = Convert.ToDateTime(citac["join_date"].ToString());
                    u.location = citac["location"].ToString();
                    u.address = citac["address"].ToString();
                    u.phone = citac["phone"].ToString();
                    u.email = citac["email"].ToString();
                    u.image_path = citac["image_path"].ToString();
                    return u;
                }
                else
                    return null;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return null;
        }

        public static Boolean CheckPassword(int id, string password)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT * FROM Users WHERE user_id=@user_id AND password=@password";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@user_id", id);
            komanda.Parameters.AddWithValue("@password", password);

            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                if (citac.Read())
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return false;
        }

        public static Boolean ChangePassword(int id, string password)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "UPDATE Users SET password=@password WHERE user_id=@user_id";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@user_id", id);
            komanda.Parameters.AddWithValue("@password", password);

            try
            {
                konekcija.Open();
                int count = komanda.ExecuteNonQuery();
                return count == 1;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return false;
        }

        public static Boolean InsertUser(string username, string password, string first_name, string last_name, Boolean gender, DateTime birth_date, DateTime join_date, string image_path, string address, string phone, string email, Boolean is_active, Boolean is_member, DateTime member_since, int occupation_id, string location, int nationality_id, int faculty_id, int organization_id)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "";
            if (is_member == false)
            {
                sqlString = "INSERT INTO Users (username, password, first_name, last_name, gender, birth_date, join_date," +
                " image_path, address, phone, email, is_active, is_member, occupation_id, location, nationality_id, faculty_id, organization_id)" +
                "VALUES (@username, @password, @first_name, @last_name, @gender, @birth_date, @join_date, @image_path, @address," +
                " @phone, @email, @is_active, @is_member, @occupation_id, @location, @nationality_id, @faculty_id, @organization_id)";
            }
            else
            {
                sqlString = "INSERT INTO Users (username, password, first_name, last_name, gender, birth_date, join_date," +
                " image_path, address, phone, email, is_active, is_member, member_since, occupation_id, location, nationality_id, faculty_id, organization_id)" +
                "VALUES (@username, @password, @first_name, @last_name, @gender, @birth_date, @join_date, @image_path, @address," +
                " @phone, @email, @is_active, @is_member, @member_since, @occupation_id, @location, @nationality_id, @faculty_id, @organization_id)";

            }

            SqlCommand komanda = new SqlCommand(sqlString, konekcija);

            if (is_member == true)
            {
                komanda.Parameters.AddWithValue("@member_since", member_since);
            }

            komanda.Parameters.AddWithValue("@username", username);
            komanda.Parameters.AddWithValue("@password", password);
            komanda.Parameters.AddWithValue("@first_name", first_name);
            komanda.Parameters.AddWithValue("@last_name", last_name);
            komanda.Parameters.AddWithValue("@gender", gender);
            komanda.Parameters.AddWithValue("@birth_date", birth_date);
            komanda.Parameters.AddWithValue("@join_date", join_date);
            komanda.Parameters.AddWithValue("@address", address);
            komanda.Parameters.AddWithValue("@phone", phone);
            komanda.Parameters.AddWithValue("@email", email);
            komanda.Parameters.AddWithValue("@is_active", is_active);
            komanda.Parameters.AddWithValue("@is_member", is_member);
            komanda.Parameters.AddWithValue("@occupation_id", occupation_id);
            komanda.Parameters.AddWithValue("@location", location);
            komanda.Parameters.AddWithValue("@nationality_id", nationality_id);
            komanda.Parameters.AddWithValue("@faculty_id", faculty_id);
            komanda.Parameters.AddWithValue("@organization_id", organization_id);

            if (image_path == null)
                komanda.Parameters.AddWithValue("@image_path", "default.jpg");
            else
                komanda.Parameters.AddWithValue("@image_path", image_path);



            string sqlString2 = "INSERT INTO URO (user_id, role_id, organization_id, start_date)" +
                "VALUES (@user_id, @role_id, @organization_id, @start_date)";
            SqlCommand komanda2 = new SqlCommand(sqlString2, konekcija);
            komanda2.Parameters.AddWithValue("@role_id", Roles.Volonteer);
            komanda2.Parameters.AddWithValue("@organization_id", organization_id);
            komanda2.Parameters.AddWithValue("@start_date", join_date);

            try
            {
                konekcija.Open();
                int count = komanda.ExecuteNonQuery();
                //   count = komanda2.ExecuteNonQuery();
                if (count == 1)
                {
                    int userID = DatabaseManagement.getIDFromUsername(username);
                    komanda2.Parameters.AddWithValue("@user_id", userID);
                    komanda2.ExecuteNonQuery();
                }
                return count == 1;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return false;
        }

        public static Boolean InsertActivity(string title, DateTime start_time, DateTime end_time, string act_description, int costs, string summary, string place, int organization_id, int activity_type_id)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "INSERT INTO Activities (title, start_time, end_time, activity_description, summary, costs, place," +
                " organization_id, activity_type_id)" +
                " VALUES (@title, @start_time, @end_time, @activity_description, @summary, @costs, @place, @organization_id, @activity_type_id)";

            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@title", title);
            komanda.Parameters.AddWithValue("@start_time", start_time);
            komanda.Parameters.AddWithValue("@end_time", end_time);
            komanda.Parameters.AddWithValue("@activity_description", act_description);
            komanda.Parameters.AddWithValue("@summary", summary);
            komanda.Parameters.AddWithValue("@costs", costs);
            komanda.Parameters.AddWithValue("@place", place);
            komanda.Parameters.AddWithValue("@organization_id", organization_id);
            komanda.Parameters.AddWithValue("@activity_type_id", activity_type_id);

            try
            {
                konekcija.Open();
                int count = komanda.ExecuteNonQuery();
                return count == 1;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return false;
        }

        public static DataSet getVolonteri(int organization_id)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT u.user_id, u.first_name, u.last_name, u.birth_date, o.organization_name, u.is_member, u.is_active, h.hours FROM Users u, Organizations o, "
           + "(SELECT user_id, SUM(hours_spent) as hours FROM UserActivities GROUP BY(user_id) UNION SELECT user_id, 0 as hours from Users WHERE user_id NOT IN (SELECT DISTINCT user_id FROM UserActivities)) h " +
                "WHERE u.organization_id = o.organization_id AND u.user_id = h.user_id "
            + "AND o.organization_id=@organization_id";


            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@organization_id", organization_id);

            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Users");
                return ds;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return ds;
        }

        public static DataSet getMembers(int organization_id)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT * FROM Users WHERE organization_id=@organization_id AND is_member=1";


            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@organization_id", organization_id);

            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Users");
                return ds;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return ds;
        }

        public static DataSet getActivities(int volonter_id)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT a.activity_id, a.title, a.start_time, a.end_time, ua.hours_spent " +
                "FROM Activities a, UserActivities ua " +
                "WHERE a.activity_id = ua.activity_id AND " +
                "ua.user_id = @volonter_id";


            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@volonter_id", volonter_id);

            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Users");
                return ds;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return ds;
        }

        public static List<int> getFeesList(int user_id)
        {
            List<int> fees = new List<int>();
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT year FROM Fees WHERE user_id = @user_id";

            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@user_id", user_id);

            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    int year = int.Parse(citac["year"].ToString());
                    fees.Add(year);
                }
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return fees;
        }

        public static DataSet getFees(int user_id)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT year FROM Fees WHERE user_id = @user_id";

            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@user_id", user_id);

            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Fees");
                return ds;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return ds;
        }

        public static DataSet getClenovi()
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT u.user_id, u.first_name, u.last_name, o.organization_name FROM Users u, Organizations o WHERE u.organization_id = o.organization_id AND u.is_member = 1";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);

            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Users");
                return ds;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return ds;
        }

        public static List<Organization> getChildOrganizations(int organization_id)
        {
            List<Organization> organizations = new List<Organization>();
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT * FROM Organizations WHERE parent_id=@organization_id";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@organization_id", organization_id);
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Organization o = new Organization(int.Parse(citac[0].ToString()), citac[1].ToString());
                    organizations.Add(o);
                }
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }

            return organizations;
        }

        public static Boolean canViewMenuItems(int user_id)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT COUNT(*) as numRoles FROM URO WHERE role_id != @role AND user_id=@user_id";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@user_id", user_id);
            komanda.Parameters.AddWithValue("@role", (int)Roles.Volonteer);

            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                if (citac.Read())
                {
                    int numRoles = int.Parse(citac["numRoles"].ToString());
                    return numRoles > 0;
                }
                else
                    return false;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return false;
        }

        public static Boolean canAddVolonteri(int user_id)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT COUNT(*) as numRoles FROM URO WHERE (role_id = @r1 OR role_id = @r2) AND user_id=@user_id";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@user_id", user_id);
            komanda.Parameters.AddWithValue("@r1", (int)Roles.ClubManager);
            komanda.Parameters.AddWithValue("@r2", (int)Roles.ViceClubManager);

            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                if (citac.Read())
                {
                    int numRoles = int.Parse(citac["numRoles"].ToString());
                    return numRoles > 0;
                }
                else
                    return false;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return false;
        }

        public static Boolean canViewVolonteriHimOrganization(int user_id, int organization_id)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT COUNT(*) as numRoles FROM URO WHERE (role_id = @r1 OR role_id = @r2 OR role_id = @r3) AND user_id=@user_id AND organization_id=@organization_id";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@user_id", user_id);
            komanda.Parameters.AddWithValue("@organization_id", organization_id);
            komanda.Parameters.AddWithValue("@r1", (int)Roles.ClubManager);
            komanda.Parameters.AddWithValue("@r2", (int)Roles.ViceClubManager);
            komanda.Parameters.AddWithValue("@r3", (int)Roles.CoordinativeMemberClub);

            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                if (citac.Read())
                {
                    int numRoles = int.Parse(citac["numRoles"].ToString());
                    return numRoles > 0;
                }
                else
                    return false;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return false;
        }

        public static Boolean canViewVolonteriAllOrganizations(int user_id)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT COUNT(*) as numRoles FROM URO WHERE (role_id = @r1 OR role_id = @r2 OR role_id = @r3 OR role_id = @r4) AND user_id=@user_id";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@user_id", user_id);
            komanda.Parameters.AddWithValue("@r1", (int)Roles.Admin);
            komanda.Parameters.AddWithValue("@r2", (int)Roles.PresidentCKRM);
            komanda.Parameters.AddWithValue("@r3", (int)Roles.VicePresidentCKRM);
            komanda.Parameters.AddWithValue("@r4", (int)Roles.CoordinativeMember);

            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                if (citac.Read())
                {
                    int numRoles = int.Parse(citac["numRoles"].ToString());
                    return numRoles > 0;
                }
                else
                    return false;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return false;
        }

        public static Boolean isUserAdmin(int user_id)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT COUNT(*) as numRoles FROM URO WHERE role_id = @r1 AND user_id=@user_id";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@user_id", user_id);
            komanda.Parameters.AddWithValue("@r1", (int)Roles.Admin);

            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                if (citac.Read())
                {
                    int numRoles = int.Parse(citac["numRoles"].ToString());
                    return numRoles > 0;
                }
                else
                    return false;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return false;
        }

        public static DataSet getActivities(int organization_id, int activity_type_id, DateTime from_date, DateTime to_date)
        {
            string sqlString = "";
            SqlConnection konekcija = getConnection();

            if (activity_type_id == 0)
            {
                sqlString = "SELECT * FROM Activities WHERE organization_id=@organization_id and @from_date<start_time and @to_date>end_time";
            }
            else
            {
                sqlString = "SELECT * FROM Activities WHERE organization_id=@organization_id and activity_type_id=@activity_type_id and @from_date<start_time and @to_date>end_time";

            }
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@activity_type_id", activity_type_id);
            komanda.Parameters.AddWithValue("@organization_id", organization_id);
            komanda.Parameters.AddWithValue("@from_date", from_date);
            komanda.Parameters.AddWithValue("@to_date", to_date);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Activities");
                return ds;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return ds;
        }

        public static int getIDFromUsername(string username)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT user_id FROM Users WHERE username=@username";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@username", username);

            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                if (citac.Read())
                {
                    int user_id = int.Parse(citac["user_id"].ToString());
                    return user_id;
                }
                else
                    return 0;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return 0;
        }

        public static List<User> getUsersByOrganization(int organization_id)
        {
            List<User> users = new List<User>();
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT * FROM Users WHERE organization_id=@organization_id and is_active=1";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@organization_id", organization_id);
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    User u = new User();
                    u.user_id = int.Parse(citac["user_id"].ToString());
                    u.first_name = citac["first_name"].ToString();
                    u.last_name = citac["last_name"].ToString();
                    u.organization_id = int.Parse(citac["organization_id"].ToString());
                    users.Add(u);
                }
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }

            return users;
        }

        public static List<User> getNonMembers(int organization_id)
        {
            List<User> users = new List<User>();
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT * FROM Users WHERE organization_id=@organization_id and is_member=0";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@organization_id", organization_id);
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    User u = new User();
                    u.user_id = int.Parse(citac["user_id"].ToString());
                    u.first_name = citac["first_name"].ToString();
                    u.last_name = citac["last_name"].ToString();

                    u.organization_id = int.Parse(citac["organization_id"].ToString());
                    users.Add(u);
                }
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }

            return users;
        }

        public static List<User> getMembersList(int organization_id)
        {
            List<User> users = new List<User>();
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT * FROM Users WHERE organization_id=@organization_id and is_member=1";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@organization_id", organization_id);
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    User u = new User();
                    u.user_id = int.Parse(citac["user_id"].ToString());
                    u.first_name = citac["first_name"].ToString();
                    u.last_name = citac["last_name"].ToString();

                    u.organization_id = int.Parse(citac["organization_id"].ToString());
                    users.Add(u);
                }
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }

            return users;
        }

        public static Boolean addMember(int user_id, DateTime start_date)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "UPDATE Users SET is_member=1, member_since=@member_since WHERE user_id=@user_id";

            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@user_id", user_id);
            komanda.Parameters.AddWithValue("@member_since", start_date);

            try
            {
                konekcija.Open();
                int count = komanda.ExecuteNonQuery();
                return count == 1;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return false;
        }

        public static List<User> getAllUsers()
        {
            List<User> users = new List<User>();
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT u.*, o.organization_name FROM Users u, Organizations o WHERE o.organization_id = u.organization_id";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);

            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    User u = new User();
                    u.user_id = int.Parse(citac["user_id"].ToString());
                    u.first_name = citac["first_name"].ToString();
                    u.last_name = citac["last_name"].ToString();
                    u.organization_name = citac["organization_name"].ToString();
                    users.Add(u);
                }
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }

            return users;
        }

        public static List<Document> getAllDocuments()
        {
            List<Document> documents = new List<Document>();
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT * FROM Documents";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);

            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    int id = int.Parse(citac["document_id"].ToString());
                    string path = citac["document_path"].ToString();
                    string title = citac["title"].ToString();
                    Document d = new Document(id, path, title);

                    documents.Add(d);
                }
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }

            return documents;
        }

        public static List<Roles> getRolesForUser(int user_id)
        {
            List<Roles> roles = new List<Roles>();
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT role_id FROM URO WHERE user_id = @user_id";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@user_id", user_id);
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    int role_id = int.Parse(citac["role_id"].ToString());
                    roles.Add((Roles) role_id);
                }
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }

            return roles;
        }

        public static Boolean saveRolesForUser(int user_id, List<int> newRoles)
        {
            User user = getUserByID(user_id);
            List<Roles> roles = getRolesForUser(user_id);
            List<int> oldRoles = new List<int>();
            for (int i = 0; i < roles.Count; i++)
            {
                oldRoles.Add((int)roles[i]);
            }
            for (int i = 0; i < oldRoles.Count; )
            {
                if (newRoles.Contains(oldRoles[i]))
                {
                    newRoles.Remove(oldRoles[i]);
                    oldRoles.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }

            SqlConnection konekcija = getConnection();
            try
            {
                konekcija.Open();

                //DELETE OLD ROLES
                for (int i = 0; i < oldRoles.Count; i++) {
                    if (oldRoles[i] == 9) continue;
                    SqlCommand komanda = new SqlCommand();
                    komanda.Connection = konekcija;
                    komanda.CommandText = "DELETE FROM URO where user_id = @user_id AND role_id = @role_id";
                    komanda.Parameters.AddWithValue("@user_id", user_id);
                    komanda.Parameters.AddWithValue("@role_id", oldRoles[i]);
                    komanda.ExecuteNonQuery();
                }

                //ADD NEW ROLES
                for (int i = 0; i < newRoles.Count; i++)
                {
                    SqlCommand komanda = new SqlCommand();
                    komanda.Connection = konekcija;
                    komanda.CommandText = "INSERT INTO URO (user_id, role_id, organization_id, start_date)" +
                "VALUES (@user_id, @role_id, @organization_id, @start_date)";

                    komanda.Parameters.AddWithValue("@user_id", user_id);
                    komanda.Parameters.AddWithValue("@role_id", newRoles[i]);
                    komanda.Parameters.AddWithValue("@organization_id", user.getOrganizationId());
                    komanda.Parameters.AddWithValue("@start_date", DateTime.Now);

                    komanda.ExecuteNonQuery();
                }

            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }

            return true;
        }

        public static DataSet getUsersOnActivity(int activity_id)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT u.user_id, u.first_name, u.last_name, ua.hours_spent FROM UserActivities ua, Users u WHERE u.user_id = ua.user_id and ua.activity_id=@activity_id";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@activity_id", activity_id);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "UsersActivity");
                return ds;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return ds;
        }

        public static int getActivityUsersCount(int activity_id)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT COUNT(*) as Broj FROM UserActivities WHERE activity_id=@activity_id GROUP BY activity_id";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@activity_id", activity_id);

            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                if (citac.Read())
                {
                    int count = int.Parse(citac["Broj"].ToString());
                    return count;
                }
                else
                    return 0;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return 0;
        }

        public static Boolean InsertUsersOnActivity(int user_id, int activity_id, float hours_spent)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "INSERT INTO UserActivities (user_id, activity_id, hours_spent)" +
                " VALUES (@user_id, @activity_id, @hours_spent)";

            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@user_id", user_id);
            komanda.Parameters.AddWithValue("@activity_id", activity_id);
            komanda.Parameters.AddWithValue("@hours_spent", hours_spent);
            try
            {
                konekcija.Open();
                int count = komanda.ExecuteNonQuery();
                return count == 1;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return false;
        }

        public static Boolean AddFee(int user_id, int year)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "INSERT INTO Fees (user_id, year)" +
                " VALUES (@user_id, @year)";

            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@user_id", user_id);
            komanda.Parameters.AddWithValue("@year", year);

            try
            {
                konekcija.Open();
                int count = komanda.ExecuteNonQuery();
                return count == 1;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return false;
        }

        public static int getFirstYearMember(int user_id) {

            SqlConnection konekcija = getConnection();
            string sqlString = "SELECT year(member_since) as year_start FROM Users WHERE user_id=@user_id";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@user_id", user_id);
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                if(citac.Read())
                {
                    int year = int.Parse(citac["year_start"].ToString());
                    return year;
                }
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }

            return 2014;
        }

        public static Boolean InsertDocument(string b, string p1, string p2, DateTime dateTime, int user_id)
        {
            SqlConnection konekcija = getConnection();
            string sqlString = "INSERT INTO Documents (document_path, policy, title, " +
                " date_created, user_id)" +
                " VALUES (@document_path, @policy, @title, @date_created, @user_id)";

            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@document_path", b);
            komanda.Parameters.AddWithValue("@policy", p1);
            komanda.Parameters.AddWithValue("@title", p2);
            komanda.Parameters.AddWithValue("@date_created", dateTime);
            komanda.Parameters.AddWithValue("@user_id", user_id);

            try
            {
                konekcija.Open();
                int count = komanda.ExecuteNonQuery();
                return count == 1;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return false;
        }*/
    }
}