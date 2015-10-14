using p7cSarlWF.Models;
using p7cSarlWF.Models.Service;
using p7cSarlWF.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace p7cSarlWF.Controllers
{
    public class RessourceController : Controller
    {
        public IRessourceManager RessourceManager { get; set; }
        public IUtilisateurManager UtilisateurManager { get; set; }
        //
        // GET: /Ressource/
        public ActionResult Index()
        {
            List<TypeRessource> typesRessources = RessourceManager.GetAllTypesRessources();
            return View(typesRessources);
        }

        //liste des types de ressources
        public ActionResult TypeList()
        {
            List<TypeRessource> typesRessources = RessourceManager.GetAllTypesRessources();
            return View(typesRessources);
        }

        //liste de toutes les ressources
        //public ActionResult RessourceList()
        //{
        //    List<Ressource> Ressources = RessourceManager.GetAllRessources();
        //    return View(Ressources);
        //}

        //liste des ressources d'un type
        public ActionResult RessourceList(int id)
        {

            List<Ressource> Ressources = RessourceManager.GetAllRessourcesByType(id);
            return View(Ressources);
        }

        [HttpGet]
        public ActionResult CreateType()
        {
            ViewBag.Utilisateurs = UtilisateurManager.GetListeAllUtilisateur();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateType(TypeRessource typeRessource)
        {
            typeRessource.CreatedDate = DateTime.Now;
            typeRessource.CreatedBy = 1;

            if (ModelState.IsValid)
            {
                RessourceManager.SaveTypeRessource(typeRessource);
                return RedirectToAction("TypeList");
            }

            return View(typeRessource);
        }

        [HttpGet]
        public ActionResult EditType(int TypeRessourceID)
        {
            TypeRessource type = RessourceManager.GetTypeRessourceByID(TypeRessourceID);
            ViewBag.Utilisateurs = UtilisateurManager.GetListeAllUtilisateur();
            return View(type);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditType(TypeRessource typeRessource)
        {
            if (ModelState.IsValid)
            {
                RessourceManager.SaveTypeRessource(typeRessource);
                return RedirectToAction("TypeList");
            }

            return View(typeRessource);
        }



        //créer une ressource (formulaire)
        [HttpGet]
        public ActionResult Create()
        {
            List<TypeRessource> TypesRessources = RessourceManager.GetAllTypesRessources();
            ViewBag.Utilisateurs = UtilisateurManager.GetListeAllUtilisateur();
            ViewBag.TypesRessources = TypesRessources;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RessourceDescription,RessourceName,TypeRessourceID")]Ressource Ressource, HttpPostedFileBase Fichiers)
        {
            if (ModelState.IsValid)
            {


                if (Fichiers != null && Fichiers.ContentLength > 0)
                {
                    TypeRessource type = RessourceManager.GetTypeRessourceByID(Ressource.TypeRessourceID);
                    var fichier = new Fichier
                    {
                        taille = P7CUtils.ConvertFileLengthToHuman(Fichiers.ContentLength),
                        OriginalFileName = System.IO.Path.GetFileName(Fichiers.FileName),
                        ContentLength = Fichiers.ContentLength,
                        ContentType = Fichiers.ContentType,
                        UploadedBy = 1
                    };
                    fichier.Md5Name = P7CUtils.CalculateMD5Hash(Guid.NewGuid().ToString()+fichier.OriginalFileName) + System.IO.Path.GetExtension(fichier.OriginalFileName);
                    fichier.CheminDisque = "~/App_Data/" + type.TypeName + "/" + Ressource.RessourceName + "/" + fichier.Md5Name;
                    
                    Fichiers.SaveAs(fichier.CheminDisque);

                    Ressource.Fichiers = new List<Fichier>();
                    Ressource.Fichiers.Add(fichier);
                    
                }


                Ressource = RessourceManager.SaveRessource(Ressource);

                return RedirectToAction("UploadRessourceFiles", new { id= Ressource.RessourceID});
            }
            List<TypeRessource> TypesRessources = RessourceManager.GetAllTypesRessources();
            ViewBag.Utilisateurs = UtilisateurManager.GetListeAllUtilisateur();
            ViewBag.TypesRessources = TypesRessources;
            return View(Ressource);
        }

        //associer des fichier à une ressource
        [HttpGet]
        public ActionResult UploadRessourceFiles(int id)
        {
            Ressource Ressource = RessourceManager.GetRessourceByID(id);

            ViewBag.Ressource = Ressource;
            RessourceFichier rf = new RessourceFichier();
            rf.RessourceID = Ressource.RessourceID;
            return View(rf);
        }

        [HttpPost]
        public ActionResult UploadRessourceFiles(RessourceFichier rf)
        {

            if (ModelState.IsValid)
            {

                Ressource Ressource = RessourceManager.GetRessourceByID(rf.RessourceID);
                TypeRessource type = RessourceManager.GetTypeRessourceByID(Ressource.TypeRessourceID);

                HttpPostedFileBase Fichiers = rf.ImageUpload;

                var fichier = new Fichier
                {
                    taille = P7CUtils.ConvertFileLengthToHuman(Fichiers.ContentLength),
                    OriginalFileName = System.IO.Path.GetFileName(Fichiers.FileName),
                    ContentLength = Fichiers.ContentLength,
                    ContentType = Fichiers.ContentType,
                    UploadedBy = 1,
                    RessourceID = Ressource.RessourceID,
                    Uplaoded_at = DateTime.Now,
                    Updated_at = DateTime.Now,
                    Deleted_at = DateTime.Now,
                };
                fichier.Md5Name = P7CUtils.CalculateMD5Hash(Guid.NewGuid().ToString() + fichier.OriginalFileName) + System.IO.Path.GetExtension(fichier.OriginalFileName);
                fichier.CheminDisque = "~/App_Data/";// +type.TypeName + "/" + Ressource.RessourceName;

                var imagePath = Path.Combine(Server.MapPath(fichier.CheminDisque), fichier.Md5Name);
                
                Fichiers.SaveAs(imagePath);
                //fichier.Ressource = Ressource;
                
                
                RessourceManager.SaveFichier(fichier);
                //Ressource.Fichiers = new List<Fichier>();
                //Ressource.Fichiers.Add(fichier);


                //RessourceManager.SaveRessource(Ressource);
                return RedirectToAction("TypeList");
            }


            return View(rf);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            Ressource Ressource = RessourceManager.GetRessourceByID(id);
            if (Ressource != null)
            {
                return View(Ressource);
            }
            else
            {
                return RedirectToAction("TypeList");
            }

        }

        [HttpPost]
        public ActionResult Edit(Ressource Ressource)
        {
            if (ModelState.IsValid)
            {
                Ressource = RessourceManager.UpdateRessource(Ressource);
                
            }
            int typeID = Ressource.TypeRessourceID;
            return RedirectToAction("RessourceList", new { id = typeID });
        }

        public ActionResult DeleteType(int id)
        {
            bool boo = RessourceManager.DeleteType(id);
            return RedirectToAction("TypeList");
        }

        public RessourceController()
        {
            RessourceManager = (IRessourceManager)System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IRessourceManager));
            UtilisateurManager = (IUtilisateurManager)System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IUtilisateurManager));
        }
	}
}