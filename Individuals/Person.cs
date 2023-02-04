using SociologySimulator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public class Person : ICommunicator
{
    public Character Character { get; set; }
    public IPersonDriver Driver { get; set; }

    public Person(Character character)
    {
        Character = character;
    }

    public Message GenerateMessage(Person receiver)
    {
        Console.WriteLine(Character.Name + " is preparing to talk to " + receiver.Character.Name);
        return Driver.GenerateMessage(receiver);
    }

    public void ReceiveMessage(Message message)
    {
        Message response = GenerateMessage(message.Speaker);
        DeliverMessage(response);
    }

    public void DeliverMessage(Message message)
    {
        Console.WriteLine(message.ToString());
        message.Receiver.ReceiveMessage(message);
    }
}