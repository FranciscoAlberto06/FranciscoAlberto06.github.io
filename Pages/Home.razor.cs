using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using FranciscoPortfolio.Models;

namespace FranciscoPortfolio.Pages;

public partial class Home : ComponentBase
{

    #region EXPLORADOR DE ARCHIVOS
    private readonly List<FileEntry> Files = new()
    {
        new("perfil",    "sobre-mi.cs",    "🗎", "PERFIL"),
        new("frivgame",  "frivgame.cs",    "🗎", "PROYECTOS"),
        new("skills",    "skills.json",    "🗎", "SKILLS"),
        new("formacion", "formacion.md",   "🗎", "FORMACION"),
        new("contacto",  "contacto.md",    "🗎", "CONTACTO"),
    };



    private List<string> Folders => Files.Select(f => f.Folder).Distinct().ToList();

    private readonly HashSet<string> openFolders = new() { "PERFIL", "PROYECTOS", "SKILLS", "FORMACION", "CONTACTO" };

    /// <summary>
    /// Metodo que comprueba si una carpeta esta abierta o cerrada en el explorador de archivos
    /// </summary>
    /// <param name="folder"></param>
    /// <returns></returns>
    private bool IsFolderOpen(string folder) => openFolders.Contains(folder);

    /// <summary>
    /// Metodo que abre o cierra una carpeta en el explorador de archivos
    /// </summary>
    /// <param name="folder"></param>
    private void ToggleFolder(string folder)
    {
        // Si la carpeta no estaba abierta, se abre, si ya estaba abierta, se cierra.
        if (!openFolders.Add(folder))
            // Si no se pudo añadir, es que ya estaba abierta, así que la cerramos.
            openFolders.Remove(folder);
    }

    #endregion

    #region PESTAÑAS

    // Lista de pestaña abiertas(predefinido de abre la de perfil)
    private List<string> OpenTabs { get; } = new() { "perfil" };

    // Pestaña activa (la que se muestra en el panel de contenido)
    private string ActiveFile { get; set; } = "perfil";

    /// <summary>
    /// Metodo que abre un archivo en el panel de contenido y lo añade a la lista de pestañas abiertas si no estaba ya abierta
    /// </summary>
    /// <param name="id"></param>
    private void OpenFile(string id)
    {
        // 1.-  Si la pestaña no estaba abierta, se añade a la lista de pestañas abiertas
        if (!OpenTabs.Contains(id))
            // Si no estaba abierta, se añade a la lista de pestañas abiertas
            OpenTabs.Add(id);

        // 2.-  Se establece como pestaña activa(la que se muestra en el panel de contenido)
        ActiveFile = id;
        BarraLateralMovilAbierta = false; // en móvil, elegir un archivo cierra el panel deslizante
    }
    #endregion

    #region PANEL LATERAL EN MOVIL

    // Estado del panel lateral en móvil (abierto o cerrado)
    private bool BarraLateralMovilAbierta { get; set; } = false;

    /// Metodo que abre o cierra el panel lateral en móvil
    private void ToggleMobileSidebar() => BarraLateralMovilAbierta = !BarraLateralMovilAbierta;
    private void CloseMobileSidebar() => BarraLateralMovilAbierta = false;

    private void CloseTab(string id)
    {
        OpenTabs.Remove(id);
        if (ActiveFile == id)
            ActiveFile = OpenTabs.LastOrDefault() ?? "";
    }

    private int StatusLine => ActiveFile switch
    {
        "perfil" => 12,
        "frivgame" => 28,
        "skills" => 19,
        "formacion" => 15,
        "contacto" => 8,
        _ => 1
    };
    #endregion

    #region CONTENIDO DE CADA PESTAÑA

    // Se generan como bloques de HTML con clases de resaltado de sintaxis (kw, typ, str, com, fn, num).

    private MarkupString RenderPerfil()
    {
        var html = $@"
<pre><code>
<span class=""com"">// sobre-mi.cs</span>

<span class=""kw"">public class</span> <span class=""typ"">Perfil</span>
{{
    <span class=""kw"">public string</span> Nombre = <span class=""str"">""Francisco Alberto Fernández Alcántara""</span>;
    <span class=""kw"">public string</span> Rol    = <span class=""str"">""Desarrollador .NET / C#""</span>;

    <span class=""kw"">public string</span> Resumen = <span class=""str"">@""Técnico Superior en Desarrollo de Aplicaciones
        Multiplataforma (DAM), especializado en desarrollo con C# y .NET.
        Experiencia en el desarrollo de APIs REST con ASP.NET Core,
        aplicaciones multiplataforma con .NET MAUI y gestión de bases
        de datos SQL. Familiarizado con Git, despliegue de aplicaciones
        en la nube y metodologías ágiles. Orientado al desarrollo
        backend y al aprendizaje continuo.""</span>;

    <span class=""kw"">public string</span>[] Idiomas = {{ <span class=""str"">""Español (nativo)""</span>, <span class=""str"">""Inglés (A2)""</span> }};
    <span class=""kw"">public string</span> Extra = <span class=""str"">""Permiso de conducir B""</span>;
}}
</code></pre>";
        return new MarkupString(html);
    }

    private MarkupString RenderFrivgame()
    {
        var html = $@"
<pre><code>
<span class=""com"">// frivgame.cs — Proyecto Final de Grado</span>
<span class=""com"">// Repositorio: github.com/FranciscoAlberto06</span>

<span class=""kw"">public class</span> <span class=""typ"">FrivGame</span> : <span class=""typ"">AplicacionMultiplataforma</span>
{{
    <span class=""com"">// App de minijuegos para Android y Escritorio,</span>
    <span class=""com"">// con funcionamiento online y offline.</span>

    <span class=""kw"">void</span> <span class=""fn"">Autenticacion</span>()
        <span class=""com"">// Registro y login de usuarios: perfiles, experiencia,</span>
        <span class=""com"">// niveles y sistema de logros.</span>

    <span class=""kw"">void</span> <span class=""fn"">RankingEnTiempoReal</span>()
        <span class=""com"">// Actualización instantánea de puntuaciones vía SignalR.</span>

    <span class=""kw"">void</span> <span class=""fn"">Api</span>()
        <span class=""com"">// ASP.NET Core + C#, desplegada en Railway,</span>
        <span class=""com"">// integrada con MySQL en Aiven.</span>

    <span class=""kw"">void</span> <span class=""fn"">ClienteMultiplataforma</span>()
        <span class=""com"">// .NET MAUI + C#, consumiendo la API REST</span>
        <span class=""com"">// en formato JSON.</span>
}}
</code></pre>";
        return new MarkupString(html);
    }

    private MarkupString RenderSkills()
    {
        var html = $@"
<pre><code>
{{
  <span class=""fn"">""lenguajes""</span>: [<span class=""str"">""C#""</span>, <span class=""str"">""Python""</span>, <span class=""str"">""Java""</span>],
  <span class=""fn"">""basesDeDatos""</span>: [<span class=""str"">""MySQL""</span>, <span class=""str"">""SQL Server""</span>, <span class=""str"">""SQLite""</span>],
  <span class=""fn"">""frameworks""</span>: [
    <span class=""str"">""ASP.NET Core""</span>,
    <span class=""str"">""ASP.NET Core Web API""</span>,
    <span class=""str"">"".NET MAUI""</span>,
    <span class=""str"">""Blazor""</span>,
    <span class=""str"">""API REST""</span>,
    <span class=""str"">""SignalR""</span>
  ],
  <span class=""fn"">""herramientas""</span>: [<span class=""str"">""Visual Studio""</span>, <span class=""str"">""Git / GitHub""</span>, <span class=""str"">""MySQL Workbench""</span>]
}}
</code></pre>";
        return new MarkupString(html);
    }

    private MarkupString RenderFormacion()
    {
        var html = $@"
<pre><code>
<span class=""com"">## formacion.md</span>

<span class=""kw"">###</span> IES Luis Carrillo de Sotomayor <span class=""com"">(2024 – 2026)</span>
Técnico Superior en Desarrollo de Aplicaciones Multiplataforma (DAM)

<span class=""kw"">###</span> IES Marqués de Comares <span class=""com"">(2022 – 2024)</span>
Técnico en Sistemas Microinformáticos y Redes (SMR)
</code></pre>";
        return new MarkupString(html);
    }

    private MarkupString RenderContacto()
    {
        var html = $@"
<pre><code>
<span class=""com"">## contacto.md</span>

- **Email:** francisfdez591@gmail.com
- **Teléfono:** 635 33 73 02
- **GitHub:** github.com/FranciscoAlberto06
- **LinkedIn:** ver enlace en la barra lateral

<span class=""com"">// psst: abre la terminal de abajo y escribe 'help'</span>
</code></pre>";
        return new MarkupString(html);
    }

    #endregion

    #region TERMINAL

    private bool TerminalOpen { get; set; } = false;
    private string TerminalInput { get; set; } = "";
    private ElementReference terminalLogRef;

    private readonly List<string> TerminalLog = new()
    {
        "franciscoalberto.dev terminal [v1.0]",
        "escribe <span class=\"str\">'help'</span> para ver los comandos disponibles."
    };

    private void ToggleTerminal() => TerminalOpen = !TerminalOpen;

    private void HandleTerminalKey(KeyboardEventArgs e)
    {
        if (e.Key != "Enter") return;

        var cmd = TerminalInput.Trim();
        TerminalLog.Add($"<span class=\"prompt-echo\">francisco@dev:~$</span> {System.Net.WebUtility.HtmlEncode(cmd)}");
        RunCommand(cmd.ToLowerInvariant());
        TerminalInput = "";
    }

    private void RunCommand(string cmd)
    {
        switch (cmd)
        {
            case "help":
                TerminalLog.Add("comandos: help · whoami · github · linkedin · email · cv · skills · clear");
                break;
            case "whoami":
                TerminalLog.Add("Francisco Alberto Fernández Alcántara — Desarrollador .NET / C#");
                break;
            case "github":
                TerminalLog.Add("abriendo github.com/FranciscoAlberto06 ↗");
                OpenLink("https://github.com/FranciscoAlberto06");
                break;
            case "linkedin":
                TerminalLog.Add("abriendo LinkedIn ↗ (actualiza el enlace en Home.razor.cs)");
                break;
            case "email":
                TerminalLog.Add("francisfdez591@gmail.com — copiado a la vista, no al portapapeles (todavía).");
                break;
            case "cv":
                OpenFile("perfil");
                TerminalLog.Add("abriendo sobre-mi.cs...");
                break;
            case "skills":
                OpenFile("skills");
                TerminalLog.Add("abriendo skills.json...");
                break;
            case "sudo hire me":
                TerminalLog.Add("[sudo] password for recruiter: ****");
                TerminalLog.Add("permiso concedido. contacto en camino ✔");
                break;
            case "clear":
                TerminalLog.Clear();
                break;
            case "":
                break;
            default:
                TerminalLog.Add($"comando no encontrado: {System.Net.WebUtility.HtmlEncode(cmd)} (prueba 'help')");
                break;
        }
    }

    private void OpenLink(string url)
    {
        // Se abre realmente con JS interop — ver el snippet en Home.razor si quieres
        // enlazarlo a window.open. Se deja como mejora sencilla para no depender de JS aquí.
    }
    #endregion


}
