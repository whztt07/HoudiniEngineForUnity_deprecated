/*
 * PROPRIETARY INFORMATION.  This software is proprietary to
 * Side Effects Software Inc., and is not to be reproduced,
 * transmitted, or disclosed in any way without written permission.
 *
 * Produced by:
 *      Side Effects Software Inc
 *		123 Front Street West, Suite 1401
 *		Toronto, Ontario
 *		Canada   M5J 2M2
 *		416-504-9876
 *
 * COMMENTS:
 * 		Contains main HAPI API constants and structures.
 * 
 */

using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace HAPI 
{
	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Defines
	
	public struct HAPI_Constants
	{		
		public const int HAPI_POSITION_VECTOR_SIZE			= 3;
		public const int HAPI_SCALE_VECTOR_SIZE				= 3;
		public const int HAPI_NORMAL_VECTOR_SIZE			= 3;
		public const int HAPI_UV_VECTOR_SIZE				= 2;

		public const int HAPI_ASSET_MAX_FILE_PATH_SIZE		= 1024;
		public const int HAPI_ASSET_MAX_NAME_SIZE			= 256;
		public const int HAPI_ASSET_MAX_INSTANCE_PATH_SIZE	= 256;

		public const int HAPI_PARM_MAX_VECTOR_SIZE			= 4;
		public const int HAPI_PARM_MAX_NAME_SIZE			= 256;
		public const int HAPI_PARM_MAX_STRING_SIZE			= 8192;

		public const int HAPI_OBJ_MAX_NAME_SIZE				= 512;
		public const int HAPI_OBJ_MAX_PATH_SIZE				= 1024;

		public const int HAPI_GEO_MAX_NAME_SIZE				= 512;
		public const int HAPI_GEO_MAX_TEX_NAME_SIZE			= 1024;
		public const int HAPI_GEO_MAX_BUMP_NAME_SIZE		= 1024;

		public const int HAPI_PRIM_MAX_VERTEX_COUNT			= 16;
	}
	
	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Enums
	
	public enum HAPI_StatusCode 
	{
		HAPI_STATUS_SUCCESS				    			= 0,
		HAPI_STATUS_FAILURE				    			= 1,
		HAPI_STATUS_ALREADY_INITIALIZED		    		= 2,
		HAPI_STATUS_NOT_INITIALIZED			    		= 3,
		HAPI_STATUS_CANT_LOADFILE			    		= 4,    
		HAPI_STATUS_CANT_OBTAIN_READLOCK_ON_GEOMETRY    = 5,
		HAPI_STATUS_ASSET_ID_INVALID		    		= 6,
		HAPI_STATUS_OBJECT_ID_INVALID		    		= 7,
		HAPI_STATUS_PARM_ID_INVALID			    		= 8,
		HAPI_STATUS_PARM_SET_FAILED			    		= 9,
		HAPI_STATUS_INVALID_ARGUMENTS		    		= 10,
		HAPI_STATUS_INVALID_RANGE_ARGUMENTS		    	= 11
	};
	
	public enum HAPI_ParmType
	{
		HAPI_PARMTYPE_INT = 0,
		HAPI_PARMTYPE_TOGGLE,
		
		HAPI_PARMTYPE_FLOAT,
		HAPI_PARMTYPE_COLOUR,
		
		HAPI_PARMTYPE_STRING,
		
		HAPI_PARMTYPE_FOLDERLIST,
		HAPI_PARMTYPE_FOLDER,
		HAPI_PARMTYPE_SEPARATOR,
		
		// Helpers
		
		HAPI_PRMTYPE_MAX, // Total number of supported parameter types.
		
		HAPI_PARMTYPE_INT_START		= HAPI_PARMTYPE_INT,
		HAPI_PARMTYPE_INT_END		= HAPI_PARMTYPE_TOGGLE,
		
		HAPI_PARMTYPE_FLOAT_START	= HAPI_PARMTYPE_FLOAT,
		HAPI_PARMTYPE_FLOAT_END		= HAPI_PARMTYPE_COLOUR,
		
		HAPI_PRMTYPE_STR_START	    = HAPI_PARMTYPE_STRING,
		HAPI_PRMTYPE_STR_END	    = HAPI_PARMTYPE_STRING,
		
		HAPI_PRMTYPE_NONVALUE_START	= HAPI_PARMTYPE_FOLDERLIST,
		HAPI_PRMTYPE_NONVALUE_END	= HAPI_PARMTYPE_SEPARATOR
	}
	
	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Main API Structs
	
	[ StructLayout( LayoutKind.Sequential ) ]
	public struct HAPI_AssetInfo 
	{
		public int id;
		
		[ MarshalAs( UnmanagedType.ByValTStr, 
					 SizeConst = HAPI_Constants.HAPI_ASSET_MAX_FILE_PATH_SIZE ) ]
		public string otlFilePath;
		
		[ MarshalAs( UnmanagedType.ByValTStr, 
					 SizeConst = HAPI_Constants.HAPI_ASSET_MAX_NAME_SIZE ) ]		
		public string assetName;
		
		[ MarshalAs( UnmanagedType.ByValTStr, 
					 SizeConst = HAPI_Constants.HAPI_ASSET_MAX_INSTANCE_PATH_SIZE ) ]		
		public string assetInstancePath;
		
		public int objectCount;
		public int parmCount;
		
		public int minVerticesPerPrimitive;
		public int maxVerticesPerPrimitive;
	}
	
	[ StructLayout( LayoutKind.Sequential ) ]
	public struct HAPI_ParmInfo
	{
		public int id;
		public int parentId;
		
		public int type;
		public int size;
		
		[ MarshalAs( UnmanagedType.U1 ) ]
		public bool hasMin;
		
		[ MarshalAs( UnmanagedType.U1 ) ]
		public bool hasMax;
		
		[ MarshalAs( UnmanagedType.U1 ) ]
		public bool hasUIMin;
		
		[ MarshalAs( UnmanagedType.U1 ) ]
		public bool hasUIMax;
		
		[ MarshalAs( UnmanagedType.R4) ]
		public float min;
		
		[ MarshalAs( UnmanagedType.R4) ]
		public float max;
		
		[ MarshalAs( UnmanagedType.R4) ]
		public float UIMin;
		
		[ MarshalAs( UnmanagedType.R4) ]
		public float UIMax;
		
		[ MarshalAs( UnmanagedType.U1 ) ]
		public bool invisible;
		
		[ MarshalAs( UnmanagedType.U1 ) ]
		public bool joinNext;
		
		[ MarshalAs( UnmanagedType.U1 ) ]
		public bool labelNone;
		
		[ MarshalAs( UnmanagedType.ByValTStr, 
					 SizeConst = HAPI_Constants.HAPI_PARM_MAX_NAME_SIZE ) ]
		public string name;
		
		[ MarshalAs( UnmanagedType.ByValTStr, 
					 SizeConst = HAPI_Constants.HAPI_PARM_MAX_NAME_SIZE ) ]		
		public string label;		
		
		[ MarshalAs( UnmanagedType.ByValArray, 
					 SizeConst = HAPI_Constants.HAPI_PARM_MAX_VECTOR_SIZE ) ]
		public int[] intValue;
		
		[ MarshalAs( UnmanagedType.ByValArray, 
					 SizeConst = HAPI_Constants.HAPI_PARM_MAX_VECTOR_SIZE, 
					 ArraySubType = UnmanagedType.R4 ) ]
		public float[] floatValue;
		
		[ MarshalAs( UnmanagedType.ByValTStr, 
					 SizeConst = HAPI_Constants.HAPI_PARM_MAX_STRING_SIZE ) ]		
		public string stringValue;	
	}
	
	[ StructLayout( LayoutKind.Sequential ) ]
	public struct HAPI_Transform 
	{
		public int id;
		
		[ MarshalAs( UnmanagedType.ByValArray, 
					 SizeConst = HAPI_Constants.HAPI_POSITION_VECTOR_SIZE, 
					 ArraySubType = UnmanagedType.R4 ) ]
		public float[] position;
		
		[ MarshalAs( UnmanagedType.R4) ]
		public float roll;
		
		[ MarshalAs( UnmanagedType.R4) ]
		public float pitch;
		
		[ MarshalAs( UnmanagedType.R4) ]
		public float yaw;
		
		[ MarshalAs( UnmanagedType.ByValArray, 
					 SizeConst = HAPI_Constants.HAPI_SCALE_VECTOR_SIZE, 
					 ArraySubType = UnmanagedType.R4 ) ]
		public float[] scale;
	}
	
	[ StructLayout( LayoutKind.Sequential ) ]
	public struct HAPI_ObjectInfo 
	{
		public int id;
		
		[ MarshalAs( UnmanagedType.ByValTStr, 
					 SizeConst = HAPI_Constants.HAPI_OBJ_MAX_NAME_SIZE ) ]
		public string name;
		
		[ MarshalAs( UnmanagedType.ByValTStr, 
					 SizeConst = HAPI_Constants.HAPI_OBJ_MAX_PATH_SIZE ) ]
		public string objectInstancePath;
		
		[ MarshalAs( UnmanagedType.U1 ) ]
		public bool hasTransformChanged;
		
		[ MarshalAs( UnmanagedType.U1 ) ]
		public bool hasGeoChanged;
	}
	
	[ StructLayout( LayoutKind.Sequential ) ]
	public struct HAPI_GeometryInfo 
	{
		[ MarshalAs( UnmanagedType.ByValTStr, 
					 SizeConst = HAPI_Constants.HAPI_GEO_MAX_NAME_SIZE ) ]
		public string name;
		
		[ MarshalAs( UnmanagedType.ByValTStr, 
					 SizeConst = HAPI_Constants.HAPI_GEO_MAX_TEX_NAME_SIZE ) ]		
		public string textureName;
		
		[ MarshalAs( UnmanagedType.ByValTStr, 
					 SizeConst = HAPI_Constants.HAPI_GEO_MAX_BUMP_NAME_SIZE ) ]		
		public string bumpName;		
		
		[ MarshalAs( UnmanagedType.ByValArray, 
					 SizeConst = HAPI_Constants.HAPI_POSITION_VECTOR_SIZE, 
					 ArraySubType = UnmanagedType.R4 ) ]
		public float[] position;
		
		[ MarshalAs( UnmanagedType.R4 ) ]
		public float roll;
		
		[ MarshalAs( UnmanagedType.R4 ) ]
		public float pitch;
		
		[ MarshalAs( UnmanagedType.R4 ) ]
		public float yaw;
		
		[ MarshalAs( UnmanagedType.ByValArray, 
					 SizeConst = HAPI_Constants.HAPI_SCALE_VECTOR_SIZE ) ]
		public float[] scale;
		
		public int vertexCount;
		public int primCount;
		public int instanceCount;
	}
	
	[ StructLayout( LayoutKind.Sequential ) ]
	public struct HAPI_RawVertex 
	{
		public int index;
		public int offset;
		
		[ MarshalAs( UnmanagedType.ByValArray, 
					 SizeConst = HAPI_Constants.HAPI_NORMAL_VECTOR_SIZE, 
					 ArraySubType = UnmanagedType.R4 ) ]
		public float[] normal;
		
		[ MarshalAs( UnmanagedType.ByValArray, 
					 SizeConst = HAPI_Constants.HAPI_POSITION_VECTOR_SIZE, 
					 ArraySubType = UnmanagedType.R4 ) ]
		public float[] position;
		
		[ MarshalAs( UnmanagedType.ByValArray, 
					 SizeConst = HAPI_Constants.HAPI_UV_VECTOR_SIZE, 
					 ArraySubType = UnmanagedType.R4 ) ]
		public float[] uv;
	}
	
	[ StructLayout( LayoutKind.Sequential ) ]
	public struct HAPI_RawPrimitive 
	{	
		public int index;
		public int offset;
		
		[ MarshalAs( UnmanagedType.ByValArray, 
					 SizeConst = HAPI_Constants.HAPI_PRIM_MAX_VERTEX_COUNT ) ]
		public int[] vertices;
		
		public int vertexCount;
		
		[ MarshalAs( UnmanagedType.ByValArray, 
					 SizeConst = HAPI_Constants.HAPI_NORMAL_VECTOR_SIZE ) ]
		public float[] normal;	
	}
	
	[ StructLayout( LayoutKind.Sequential ) ]
	public struct HAPI_RawInstance 
	{
		public int index;
		
		[ MarshalAs( UnmanagedType.ByValArray, 
					 SizeConst = HAPI_Constants.HAPI_POSITION_VECTOR_SIZE ) ]
		public float[] position;
		
		[ MarshalAs( UnmanagedType.R4) ]
		public float roll, pitch, yaw;
		
		[ MarshalAs( UnmanagedType.ByValArray, 
					 SizeConst = HAPI_Constants.HAPI_SCALE_VECTOR_SIZE ) ]
		public float[] scale;
	}
	
}