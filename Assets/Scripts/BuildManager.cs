using UnityEngine;
public class BuildManager : MonoBehaviour
{
  public static BuildManager instance;

  private void Awake()
  {
    if (instance != null)
    {
      Debug.LogError("More than one BuildManager in the scene!");
      return;
    }
    instance = this;
  }

  public GameObject buildEffect;

  private TurretBlueprint turretToBuild;

  public bool CanBuild
  {
    get { return turretToBuild != null; }
  }
  
  public bool HasMoney
  {
    get { return PlayerStats.Money >= turretToBuild.cost; }
  }

  public void BuildTurretOn(Node node)
  {
    if (PlayerStats.Money < turretToBuild.cost)
    {
      Debug.Log("Not Enough Money to build that!");
      return;
    }

    PlayerStats.Money -= turretToBuild.cost;

    var turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
    node.turret = turret;

    var effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
    Destroy(effect, 5f);    
    
    Debug.Log($"Turret built! Money left:{PlayerStats.Money}");
  }
  
  public void SelectTurretToBuild(TurretBlueprint turret)
  {
    turretToBuild = turret;
  }
}
