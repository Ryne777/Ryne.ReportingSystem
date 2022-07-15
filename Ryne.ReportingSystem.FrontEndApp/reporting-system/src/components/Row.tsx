import { useLocation, useNavigate } from "react-router-dom";

interface IRowProps<ObjectType> {
  object: ObjectType,
  counter: number,
  path?: string,
  properties: {
    key: keyof ObjectType,
    title: string,
  }[];

}
function Row<ObjectType extends { id: string }>(
  { object, properties, counter, path }: IRowProps<ObjectType>
) {
  const navigate = useNavigate()
  const location = useLocation()
  if (path == null) {
    path = location.pathname
  }
  return (
    <tr onClick={() => navigate(`${path}/${object.id}`)} style={{ cursor: "pointer" }}>
      <td>
        {counter}
      </td>
      {properties.map((property) => (
        <td key={String(property.key)}>
          <>
            {String(property.key).startsWith("date")
              ? new Date(String(object[property.key])).toLocaleDateString("ru-RU")
              : object[property.key]}
          </>
        </td>
      ))
      }
    </tr>
  );
}
export default Row