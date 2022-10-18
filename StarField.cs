using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarField : MonoBehaviour
{
    public ParticleSystem StarEmiter; //The particle system that will act as the star field
    public int MaxStars; //Maximum number of stars to be created
    public int FieldRadius; //How big should the field be?
    public float MinimumStarSize; //The smallest allowed star size
    public float MaximumStarSize; //The biggest allowed star size 
    public ParticleSystemShapeType StarFieldShape; //Drop down menu containing types of particle system shapes

    void Start()
    {
        //WARNING DISPLAY
        Debug.LogWarning("Box shape Particle System types are not currently supported!,neither are custom meshes or cones");
        //Prepare Default Particle System Variables for star field generation
        StarEmiter.loop = true;
        var mainModule = StarEmiter.main;
        mainModule.prewarm = true;
        mainModule.startSpeed = 0;
        mainModule.simulationSpace = ParticleSystemSimulationSpace.Local;
        mainModule.startLifetime = 1000000;
        var shapeModule = StarEmiter.shape;
        shapeModule.shapeType = StarFieldShape;

        //Star field variables
        StarEmiter.maxParticles = MaxStars;
        var shape = StarEmiter.shape;
        shape.radius = FieldRadius;
        mainModule.startSize = new ParticleSystem.MinMaxCurve(MinimumStarSize, MaximumStarSize);

        //EMIT
        StarEmiter.Emit(MaxStars);
    }

}