import { useLocation, useNavigate } from "react-router-dom";

interface IRowProps<ObjectType> {
  object: ObjectType,
  counter: number,
  properties: {
    key: keyof ObjectType,
    title: string,
  }[];

}
function Row<ObjectType extends { id: string }>(
  { object, properties, counter }: IRowProps<ObjectType>
) {
  const navigate = useNavigate()
  const location = useLocation()
  return (
    <tr onClick={() => navigate(`${location.pathname}/${object.id}`)} style={{ cursor: "pointer" }}>
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