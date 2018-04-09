using System;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace PI_Searchfood.Logica.BL
{
    public class clsGeneral
    {
        public void setEMail (Models.clsCorreo obclsCorreo)
        {
            try
            {
                //objeto del correo
                MailMessage Mail = new MailMessage();

                Mail.From = new MailAddress(obclsCorreo.stFrom);
                Mail.To.Add(obclsCorreo.stTo);
                Mail.Subject = obclsCorreo.stAsunto;
                Mail.Body = obclsCorreo.stMensaje;

                if (obclsCorreo.intipo == 0) Mail.IsBodyHtml = false;
                else if (obclsCorreo.intipo == 1) Mail.IsBodyHtml = true;

                if (obclsCorreo.inPrioridad == 2) Mail.Priority = MailPriority.High;
                else if (obclsCorreo.inPrioridad == 1) Mail.Priority = MailPriority.Low;
                else if (obclsCorreo.inPrioridad == 0) Mail.Priority = MailPriority.Normal;

                AlternateView htmlview = AlternateView.CreateAlternateViewFromString(obclsCorreo.stMensaje,
                Encoding.UTF8, MediaTypeNames.Text.Html);

                //incrustando una imagen
                LinkedResource img = new LinkedResource(obclsCorreo.stImagen, MediaTypeNames.Image.Gif);
                img.ContentId = obclsCorreo.stIdImagen;
                htmlview.LinkedResources.Add(img);
                Mail.AlternateViews.Add(htmlview);

                //Cliente de servidor de correo
                SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.Host = obclsCorreo.stServidor;

                if (obclsCorreo.blAutenticacion) smtp.Credentials = new System.Net.NetworkCredential(obclsCorreo.stUsuario, obclsCorreo.stPassword);
                if (obclsCorreo.stServidor.Length > 0) smtp.Port = Convert.ToInt32(obclsCorreo.stPuerto);

                smtp.EnableSsl = obclsCorreo.blConexionSegura;
                smtp.Send(Mail);
            }
            catch (Exception ex) { throw ex; }

        }
    }
}
