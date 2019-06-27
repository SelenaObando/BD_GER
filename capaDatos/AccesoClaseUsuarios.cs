using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEntidades;
using System.Data.SqlClient;

namespace capaDatos
{
    class AccesoClaseUsuarios
    {
        SqlConnection cnx; //conexion
        Usuarios us = new Usuarios();
        Conexion cn = new Conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<Usuarios> Usuarios = null;
    }

    public int insertarUsuarios(Usuarios u)
    {
    try 
    {
    SqlConnection cnx= cn.conectar(); //conexion
    cm= new SqlCommand("usuarios_pr", cnx);
    cm.Parameters.AddWithValue("@b", 1);
    cm.Parameters.AddWithValue("@idusuario", "");
    cm.Parameters.AddWithValue("@cedula", u.cedula);
    cm.Parameters.AddWithValue("@nombres", u.nombres);
    cm.Parameters.AddWithValue("@apellidos", u.apellidos);
    cm.Parameters.AddWithValue("@email", u.email);
    cm.Parameters.AddWithValue("@telefono", u.telefono);
   

    cm.CommandType= CommandType.StoredProcedure;
    cnx.Open();
    cm.ExecuteNonQuery();
    indicador= 1;

    }
    catch(Exception e)
    {
        e.Message.ToString();
        indicador=0;
    }
    finally
    {
     cm.Connection.Close();
    }
      return indicador;

    }

public List<Usuarios> listarUsuarios()
{
try
{
SqlConnection cnx= cn.Conectar();
cm= new SqlCommand("usuarios_pr", cnx);
cm.Parameters.AddWithValue("@b", 3);
cm.Parameters.AddWithValue("@idusuario", "");
cm.Parameters.AddWithValue("@cedula", "");
cm.Parameters.AddWithValue("@nombres", "");
cm.Parameters.AddWithValue("@apellidos", "");
cm.Parameters.AddWithValue("@email", "");
cm.Parameters.AddWithValue("@telefono", "");

cm.CommandType= CommandType.StoredProcedure;
cnx.Open();
dr= cm.ExecuteReader();
listausuarios= new list<Usuarios>();
while (dr.Read)
{
Usuarios usi= new Usuarios();
usi.idusuario= convert.Toint32(dr["Idusuario"].ToString());
usi.cedula=dr["Cedula"].ToString();
usi.nombres= dr["Nombres"].ToString();
usi.apellidos= dr["Apellidos"].ToString();
usi.email= dr["Email"].ToString();
usi.telefono= dr["Telefono"].ToString();
listaUsuarios.Add(usi);
}
}
catch (Excepcion e)
{
e.Message.ToString();
listaUsuarios= null;
}
finally
{
cm.Connection.Close()
}
return listaUsuarios;
}

public int EliminarUsuarios(int idusuari)
{
try
{
SqlConnection cnx=cn.Conectar();
cm=new SqlCommand("recursos_proc", cnx);
cm.Parameters.AddWithValue("@b", 2);
cm.Parameters.AddWithValue("@idusuario", idsuari);
cm.Parameters.AddWithValue("cedula", "");
cm.Parameters.AddWithValue("@nombres", "");
cm.Parameters.AddWithValue("@apellidos", "");
cm.Parameters.AddWithValue("@email", "");
cm.Parameters.AddWithValue("@telefono", "");

cm.CommandType=CommandType.StoredProcedure;
cnx.Open();
cm.ExecuteNonQuery();
indicador=1;
}
catch(Excepcion e)
{
e.Message.ToString();
indicador=0;
}
finally
{
cm.Connection.Close();
}
return indicador;
}

public int EditarRecursos(Recursos re)
{
try
{
SqlConnection cnx= cn.Conectar();
cm.new SqlCommand("usuarios_pr", cnx);
cm.Parameters.AddWithValue("@b", 4);
cm.Parameters.AddWithValue("@idusuario", re.idusuari);
cm.Parameters.AddWithValue("@cedula", "");
cm.Parameters.AddWithValue("@nombres", "");
cm.Parameters.AddWithValue("@apellidos", "");
cm.Parameters.AddWithValue("@email", "");
cm.Parameters.AddWithValue("@telefono", "");

cm.CommandType=CommandType.StoredProcedure;
cnx.Open();
cm.ExecuteNonQuery();
indicador=1;

}
catch(Excepcion e)
{
e.Message.ToString();
indicador=0;
}
finally
{
cm.Connection.Close();
}
return indicador;
}

public List<Usuarios> BuscarUsuarios(String dato)
{
try
{
SqlConnection cnx=cn.Conectar();
cm= new SqlCommand("usuarios_pr", cnx);
cm.Parameters.AddWithValue("@b", 5);
cm.Parameters.AddWithValue("@idusuario", "");
cm.Parameters.AddWithValue("@cedula", "");
cm.Parameters.AddWithValue("@nombres", dato);
cm.Parameters.AddWithValue("@apellidos", "");
cm.Parameters.AddWithValue("@email", "");
cm.Parameters.AddWithValue("@telefono", "");

cm.CommandType=CommandType.StoredProcedure;
cnx.Open();
dr=cm.ExecuteReader();
listaUsuarios= new List<Usuarios>();
while(dr.Read())
{
Usuarios usi= new Usuarios();
usi.idusuario= convert.ToInt32(dr["Idusuario"].ToString());
usi.cedula= dr["Cedula"].ToString();
usi.nombres= dr["Codigo"].ToString();
usi.apellidos= dr["Descripcion"].ToString();
usi.email= dr["Email"].ToString();
usi.telefono= dr["Telefono"].ToString();
listaUsuarios.Add(usi);
}
}
catch(Excepcion e)
{
e.Message.ToString();
listaUsuarios=null;

}
finally
{
cm.Connection.Close();
}
return listaUsuarios;
}
    }
    }
}
