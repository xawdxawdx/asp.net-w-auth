namespace DanilaWebApp.Models
{
    public class SupportedCommunicationType
    {
        public int Id { get; set; }
        
        public virtual PhoneCharacteristic  PhoneCharacteristic { get; set; }
        
        public int PhoneCharacteristicId { get; set; }
        
        public virtual CommunicationType CommunicationType { get; set; }
        
        public int CommunicationTypeId { get; set; }
        
    }
}