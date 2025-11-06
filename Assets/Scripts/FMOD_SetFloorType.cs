using UnityEngine;
using FMODUnity;

public class FMOD_SetFloorType : MonoBehaviour
{
        [ParamRef]
        public string Parameter;
        private FMOD.Studio.PARAMETER_DESCRIPTION parameterDescription;
        public FMOD.Studio.PARAMETER_DESCRIPTION ParameterDescription { get { return parameterDescription; } }
        

        private void Start()
        {
                // Initialize FMOD parameter description
                InitializeFMODParameter();
        }

        private void InitializeFMODParameter()
        {
                // Get the FMOD parameter description by name
                FMOD.RESULT result = RuntimeManager.StudioSystem.getParameterDescriptionByName(Parameter, out parameterDescription);
                if (result != FMOD.RESULT.OK)
                {
                Debug.LogError("FMOD parameter initialization failed. " + result.ToString());
                }
                else
                {
                Debug.Log("FMOD parameter initialized successfully.");
                }
        }

        public void DetermineTerrain(){
                RaycastHit[] hit;
                // a bit in front of the player
                Vector3 raycastOrigin = transform.position + new Vector3(0, 1f, 0) + transform.forward * 0.5f;
                hit = Physics.RaycastAll(raycastOrigin, Vector3.down, 10.0f);
                int value = 0;

                foreach (RaycastHit rayhit in hit)
                {

                        if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Carpet"))
                        {
                                value = 1;
                                break;
                        }
                        else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Tile"))
                        {
                                value = 2;
                                break;
                        }
                        else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Bedroom"))
                        {
                                value = 3;
                                break;
                        }
                        else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Wood"))
                        {
                                value = 0;
                                break;
                        }
                }

                RuntimeManager.StudioSystem.setParameterByID(parameterDescription.id, value);
        }
}
