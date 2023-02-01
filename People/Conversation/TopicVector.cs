using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System;

public class TopicVector {
	public string topic {get;set;}
	public List<float> vector {get;set;}

	public static List<TopicVector> ReadCSV(string path){
		string text = File.ReadAllText(path);
		List<TopicVector> topicVectors = JsonSerializer.Deserialize<List<TopicVector>>(text);
		return topicVectors;
	}

	public override string ToString(){
		return topic + ": [" + string.Join(", ", vector) + "]";
	}
}